using SpecFlowSkeleton.PageObjects;
using SpecFlowSkeleton.Pages;

namespace SpecFlowSkeleton.StepDefinitions
{
    [Binding]
    public sealed class BasicExampleSteps
    {
        private readonly PlaywrightPage _playwrightPage;

        public BasicExampleSteps(PlaywrightPage playwrightPage)
        {
            _playwrightPage = playwrightPage;
        }

        [Given(@"a user that navigates to the website")]
        public async Task GivenAUserThatNavigatesToTheWebsite()
        {
            await _playwrightPage.GotoAsync();
        }

        [Given(@"he clicks on the dotnet doc option")]
        public async Task GivenHeClicksOnTheDotnetDocOption()
        {
            await _playwrightPage.ClickAsync(PlaywrightPageObject.DotnetDocOption);
        }

        [Given(@"he clicks on the get started button")]
        public async Task GivenHeClicksOnTheGetStartedButton()
        {
            await _playwrightPage.ClickAsync(PlaywrightPageObject.GetStartedButton);
        }

        [Then(@"the installation instructions should be available")]
        public async Task ThenTheInstallationInstructionsShouldBeAvailable()
        {
            await _playwrightPage.IsVisibleAsync(PlaywrightPageObject.InstallationText);
        }




    }
}