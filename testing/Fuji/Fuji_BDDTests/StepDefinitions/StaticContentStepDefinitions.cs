using Fuji_BDDTests.PageObjects;

namespace Fuji_BDDTests.StepDefinitions
{
    [Binding]
    public class StaticContentStepDefinitions
    {
        private readonly HomePage _homePage;

        public StaticContentStepDefinitions(HomePage page)
        {
            _homePage = page;
        }

        [Given(@"I am a visitor")]
        public void GivenIAmAVisitor()
        {
            // Assuming browser starts as an incognito session then we are a visitor already
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _homePage.Goto();
        }

        [Then(@"I can see that Apples can be eaten")]
        public void ThenICanSeeThatApplesCanBeEaten()
        {
            _homePage.GetTitle.Should().ContainEquivalentOf("Apples", AtLeast.Once());
        }
    }
}
