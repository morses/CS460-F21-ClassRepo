using System;
using TechTalk.SpecFlow;

namespace Fuji_BDDTests.StepDefinitions
{
    [Binding]
    public class InClassExamplesStepDefinitions
    {
        [Given(@"I am on the Search page")]
        public void GivenIAmOnTheSearchPage()
        {
            //_searchPage.Goto();
            throw new PendingStepException();
        }

        [When(@"I search for a TV show")]
        public void WhenISearchForATVShow()
        {
            throw new PendingStepException();
        }

        [Then(@"I will see a list of shows in the results")]
        public void ThenIWillSeeAListOfShowsInTheResults()
        {
            throw new PendingStepException();
        }

        [When(@"I search for a TV show called (.*)")]
        public void WhenISearchForATVShowCalled(string showName)
        {
            throw new PendingStepException();
        }

        [Then(@"I will see a list of shows in the results that contain the show (.*)")]
        public void ThenIWillSeeAListOfShowsInTheResultsThatContainTheShow(string showName)
        {
            throw new PendingStepException();
        }
    }
}
