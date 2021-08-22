using Skraypr.Features.Enums;
using System;

namespace Skraypr.Features.Pages
{
    public class PageResult
    {
        public TimeSpan Duration { get; set; }
        public string ErrorMessage { get; set; }
        public PageStatusEnum PageStatus { get; set; }
    }
}