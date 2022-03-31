using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace Fuji_BDDTests.PageObjects
{
    public class HomePage
    {
        private readonly IBrowserInteractions _browserInteractions;

        private const string PageUrl = "https://localhost:7100/";

        private IWebElement Title => _browserInteractions.WaitAndReturnElement(By.Id("title"));

        public HomePage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        public void Goto()
        {
            _browserInteractions.GoToUrl(PageUrl);
        }

        public string GetTitle => Title.Text;

    }
}
