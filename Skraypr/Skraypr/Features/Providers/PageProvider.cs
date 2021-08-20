using Ardalis.GuardClauses;
using Skraypr.Features.Pages;
using System;
using System.Collections.Generic;
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

        public void Execute()
        {
            //--initialize selenium driver
            InitializeDriver();

            //--initialize pages
            //--navigate to base url
            //--TODO

            foreach (var page in _pages)
            {
                ExecutePage();
            }

            /*  loop through pages
                - start page timer
                - execute page
                - set final page status
                - catch errors
                    - clean up selenium driver
                - return page results
            */

            CleanUpPageDriver();
            //--clean up selenium driver
        }

        public bool InitializeAndValidatePages()
        {
            if (_pages.Count() != _pages.Distinct().Count())
            {
                throw new InvalidOperationException("Pages must have a distinct page order.");
            }

            _pages = _pages.OrderBy(page => page.PageOrder);

            return true;
        }

        private void CleanUpPageDriver() => throw new NotImplementedException();

        private void ExecutePage() => throw new NotImplementedException();

        private void InitializeDriver() => throw new NotImplementedException();
    }
}