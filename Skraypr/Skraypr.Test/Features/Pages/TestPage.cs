using Skraypr.Features.Pages;
using System;

namespace Skraypr.Test.Features.Pages
{
    public class TestPage : Page
    {
        public TestPage() : base(1, "resourceAddress")
        {
        }

        public override void ExecutePage()
        {
            throw new NotImplementedException();
        }
    }
}