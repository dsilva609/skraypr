﻿using Skraypr.Features.Pages;
using Skraypr.Features.Providers;
using System.Collections.Generic;

namespace Skraypr.Test.Features.Providers
{
    public class TestProvider : PageProvider
    {
        public TestProvider(string baseUrl, IEnumerable<Page> pages, ISeleniumProvider seleniumProvider) : base(baseUrl, pages, seleniumProvider)
        {
        }
    }
}