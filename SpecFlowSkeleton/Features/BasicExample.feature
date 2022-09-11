Feature: BasicExample
![PlaywrightLogo](https://www.returngis.net/wp-content/uploads/2021/10/Playwright-logo.png)
Simple navigation through the Playwright Doc website to build a Playwright & Specflow skeleton for more complex tests

@specflowPlaywrightSkeleton
Scenario: Navigating through Playwright's website
	Given a user that navigates to the website
	And he clicks on the dotnet doc option
	And he clicks on the get started button
	Then the installation instructions should be available