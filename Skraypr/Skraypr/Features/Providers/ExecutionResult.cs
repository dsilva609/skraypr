using Skraypr.Features.Enums;
using Skraypr.Features.Pages;
using System;
using System.Collections.Generic;

namespace Skraypr.Features.Providers
{
    public class ExecutionResult
    {
        public ProviderStatusEnum ExecutionStatus { get; set; }
        public IEnumerable<PageResult> PageResults { get; set; }
        public TimeSpan TotalDuration { get; set; }
    }
}