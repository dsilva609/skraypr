using OpenQA.Selenium.Chrome;

namespace Skraypr.Features.Providers
{
    public class SeleniumProvider : ISeleniumProvider
    {
        public ChromeDriver Driver { get; }

        public SeleniumProvider() => Driver = new ChromeDriver();

        public void CleanUpDriver() => Driver.Dispose();

        public void InitializeDriver(string baseUrl) => Driver.Url = baseUrl;
    }
}