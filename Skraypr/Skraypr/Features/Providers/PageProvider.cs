using Ardalis.GuardClauses;
using Skraypr.Features.Enums;
using Skraypr.Features.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Skraypr.Features.Providers
{
    public abstract class PageProvider
    {
        private readonly string _baseUrl;
        private IEnumerable<Page> _pages;

        protected PageProvider(string baseUrl, IEnumerable<Page> pages)
        {
            Guard.Against.NullOrWhiteSpace(baseUrl, nameof(baseUrl));
            Guard.Against.NullOrEmpty(pages, nameof(pages));

            _baseUrl = baseUrl;
            _pages = pages;

            InitializeAndValidatePages();
        }

        public ExecutionResult Execute()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            //--initialize selenium driver
            InitializeDriver();

            //--initialize pages
            //--navigate to base url
            //--TODO

            foreach (var page in _pages)
            {
                var pageResult = ExecutePage(page);

                if (pageResult == PageStatusEnum.Errored)
                {
                    //--whoopsie doodle
                    break;
                }
            }

            stopWatch.Stop();

            CleanUpPageDriver();
            //--clean up selenium driver

            return GenerateResults(stopWatch.Elapsed);
        }

        public bool InitializeAndValidatePages()
        {
            if (!_pages.Any())
            {
                throw new InvalidOperationException("No pages added for execution");
            }

            if (_pages.Count() != _pages.Distinct().Count())
            {
                throw new InvalidOperationException("Pages must have a distinct page order.");
            }

            _pages = _pages.OrderBy(page => page.PageOrder);

            return true;
        }

        private void CleanUpPageDriver() => throw new NotImplementedException();

        private PageStatusEnum ExecutePage(Page page)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                page.ExecutePage();
            }
            catch (Exception e)
            {
                stopwatch.Stop();

                page.SetCompleted(stopwatch.Elapsed);
                page.SetPageStatus(PageStatusEnum.Errored, e.Message);

                return page.PageStatus;
            }

            stopwatch.Stop();

            page.SetCompleted(stopwatch.Elapsed);
            page.SetPageStatus(PageStatusEnum.Complete);

            return page.PageStatus;
        }

        private ExecutionResult GenerateResults(TimeSpan providerExecutionDuration)
        {
            var result = new ExecutionResult
            {
                ExecutionStatus = _pages.LastOrDefault().PageStatus == PageStatusEnum.Complete
                    ? ProviderStatusEnum.Successful
                    : ProviderStatusEnum.Errored,
                PageResults = _pages.Select(page => page.GetPageResult()),
                TotalDuration = providerExecutionDuration
            };

            return result;
        }

        private void InitializeDriver() => throw new NotImplementedException();
    }
}