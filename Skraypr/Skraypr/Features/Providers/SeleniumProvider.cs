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
            //chromeOptions.AddArguments("headless");

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