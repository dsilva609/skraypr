using Ardalis.GuardClauses;
using Skraypr.Features.Enums;
using System;

namespace Skraypr.Features.Pages
{
    public abstract class Page
    {
        protected readonly string _resourceAddress;
        public TimeSpan ExecutionDuration { get; private set; }
        public bool IsComplete { get; private set; }
        public string Message { get; private set; }
        public int PageOrder { get; }
        public PageStatusEnum PageStatus { get; private set; }

        protected Page(int pageOrder, string resourceAddress)
        {
            Guard.Against.NegativeOrZero(pageOrder, nameof(pageOrder));

            PageOrder = pageOrder;

            _resourceAddress = resourceAddress;
        }

        public abstract void ExecutePage();

        public PageResult GetPageResult()
            => new()
            {
                Duration = ExecutionDuration,
                ErrorMessage = Message,
                PageStatus = PageStatus
            };

        public void SetCompleted(TimeSpan duration)
        {
            ExecutionDuration = duration;
            IsComplete = true;

            SetPageStatus(PageStatusEnum.Complete);
        }

        public void SetPageStatus(PageStatusEnum pageStatus, string message = "")
        {
            Message = message;
            PageStatus = pageStatus;
        }
    }
}