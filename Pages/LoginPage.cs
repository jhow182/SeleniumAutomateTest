using AutomationTest.Common;
using OpenQA.Selenium;

namespace AutomationTest.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly BaseConfigurations _baseConfigurations;

        public LoginPage(IWebDriver driver, BaseConfigurations baseConfigurations)
        {
            _driver = driver;
            _baseConfigurations = baseConfigurations;
        }

        public void OpenPageLogin()
        {
            _driver.Navigate().GoToUrl(_baseConfigurations.UrlLogin);
        }

        public void OpenPageCadastro()
        {
            _driver.Navigate().GoToUrl(_baseConfigurations.UrlCadastro);
        }




        public void Login()
        {
            _driver.FindElement(By.CssSelector("input.txtbox .ng-valid .ng-touched .ng-dirty .ng-valid-parse")).SendKeys(_baseConfigurations.MasterLogin);
            _driver.FindElement(By.XPath("input.txtbox .ng-pristine .ng-valid .ng-touched")).SendKeys(_baseConfigurations.MasterPass);
            _driver.FindElement(By.Id("enterbtn")).Submit();
        }
    }
}
