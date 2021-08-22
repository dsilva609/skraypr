using OpenQA.Selenium.Chrome;

namespace Skraypr.Features.Providers
{
    public interface ISeleniumProvider
    {
        ChromeDriver Driver { get; }

        void CleanUpDriver();

        void InitializeDriver(string baseUrl);
    }
}