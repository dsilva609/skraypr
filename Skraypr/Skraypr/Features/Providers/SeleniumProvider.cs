using OpenQA.Selenium.Chrome;
using System;

namespace Skraypr.Features.Providers
{
    public class SeleniumProvider : ISeleniumProvider
    {
        public ChromeDriver Driver { get; }

        public SeleniumProvider()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions = $"{Environment.CurrentDirectory}/chromedriver.exe";
            //chromeOptions.AddArguments("headless");

            //var chromeDriverService = ChromeDriverService.CreateDefaultService();
            Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
        }

        public void CleanUpDriver()
        {
            Driver.Close();
            Driver.Dispose();
        }

        public void InitializeDriver(string baseUrl) => Driver.Url = baseUrl;
    }
}