using TechTalk.SpecFlow.Assist;
using Fuji_BDDTests.PageObjects;
using NUnit.Framework;

namespace Fuji_BDDTests.StepDefinitions
{
    #nullable disable warnings

    public class TestApple
    {
        public string VarietyName { get; set; }
        public string ScientificName { get; set; }
    }

    [Binding]
    public class EatingApplesStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HomePage _homePage;

        public EatingApplesStepDefinitions(ScenarioContext context, HomePage homePage)
        {
            _scenarioContext = context;
            _homePage = homePage;
        }

        [Given(@"the following apples exist")]
        public void GivenTheFollowingApplesExist(Table table)
        {
            IEnumerable<TestApple> apples = table.CreateSet<TestApple>();
            _scenarioContext["Apples"] = apples;
        }

        [When(@"I record eating an apple")]
        public void WhenIRecordEatingAnApple()
        {
            // Pick an apple to eat
            int appleToEatIndex = 1;
            string appleText = _homePage.GetAppleButtonText(appleToEatIndex);
            // Look up and store which test apple this is

            _scenarioContext["TestAppleEaten"] = ((IEnumerable<TestApple>)_scenarioContext["Apples"])
                                    .Where(ta => appleText.Contains(ta.VarietyName, StringComparison.OrdinalIgnoreCase))
                                    .First();
            // also store count before clicking
            _scenarioContext["AppleEatenCount"] = -65;  // no idea since it literally isn't in the page anywhere!  The test is exposing a less than ideal UI experience.
            // click the button to eat one
            _homePage.ClickAppleButton(appleToEatIndex);
        }


        [Then(@"I can see all the apples")]
        public void ThenICanSeeAllTheApples()
        {
            IEnumerable<string> appleTexts = _homePage.GetAppleButtonTexts();
            IEnumerable<TestApple> testApples = (IEnumerable<TestApple>)_scenarioContext["Apples"];
            foreach (TestApple ta in testApples)
            {
                // check that each test apple is found in exactly one button
                Assert.That(appleTexts.Count(a => a.Contains(ta.VarietyName, StringComparison.OrdinalIgnoreCase)
                                           && a.Contains(ta.ScientificName, StringComparison.OrdinalIgnoreCase)), Is.EqualTo(1));
            }
        }

        [Then(@"I see the count of that apple has increased by (.*)")]
        public void ThenISeeTheCountOfThatAppleHasIncreasedBy(int p0)
        {
            throw new PendingStepException();
        }
    }
}
