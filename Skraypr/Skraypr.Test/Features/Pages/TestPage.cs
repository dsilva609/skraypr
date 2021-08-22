using OpenQA.Selenium.Chrome;
using Skraypr.Features.Pages;

namespace Skraypr.Test.Features.Pages
{
    public class TestPage : Page
    {
        public TestPage(string resourceAddress) : base(1, resourceAddress)
        {
        }

        public override void ExecutePage(ChromeDriver driver)
        {
            driver.Navigate().GoToUrl($"{driver.Url}/{_resourceAddress}");
        }
    }
}