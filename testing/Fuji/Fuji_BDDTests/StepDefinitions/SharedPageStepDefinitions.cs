using TechTalk.SpecFlow.Assist;
using Fuji_BDDTests.PageObjects;

namespace Fuji_BDDTests.StepDefinitions
{
    [Binding]
    public class SharedPageStepDefinitions
    {
        #nullable disable warnings

        private readonly ScenarioContext _scenarioContext;
        private readonly Page _page;

        public SharedPageStepDefinitions(ScenarioContext context, Page page)
        {
            _scenarioContext = context;
            _page = page;
        }

        [Given(@"I am on the '([^']*)' page")]
        [When(@"I am on the '([^']*)' page")]
        public void WhenIAmOnThePage(string pageName)
        {
            _page.Goto(pageName);
        }

        [Then(@"I am redirected to the '([^']*)' page")]
        public void ThenIAmRedirectedToThePage(string pageName)
        {
            _page.GetCurrentUrl().Should().Be(Common.UrlFor(pageName));
        }

    }
}
