using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;

namespace AutomationTest.Common
{
    public class BaseTest
    {
        public IWebDriver driver;
        public BaseConfigurations baseConfigurations;

        [SetUp]
        public void BaseSteps()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("TestSettings.json");

            var configuration = builder.Build();

            var seleniumConfigurations = new SeleniumConfigurations();
            new ConfigureFromConfigurationOptions<SeleniumConfigurations>(
                configuration.GetSection("SeleniumConfigurations"))
                    .Configure(seleniumConfigurations);

            baseConfigurations = new BaseConfigurations();
            new ConfigureFromConfigurationOptions<BaseConfigurations>(
                configuration.GetSection("BaseConfigurations"))
                    .Configure(baseConfigurations);

            if (seleniumConfigurations.Headless)
            {
                var options = new ChromeOptions();
                options.AddArgument("--headless");
                driver = new ChromeDriver(options);
            } else
            {
                driver = new ChromeDriver();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seleniumConfigurations.Timeout);
            driver.Manage().Window.Size = new Size(1440, 900);
        }

        [TearDown]
        public void Quit()
        {
            driver.Close();
        }
    }
}