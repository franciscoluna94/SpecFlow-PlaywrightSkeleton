Feature: BasicExample
![PlaywrightLogo](https://image.pngaaa.com/84/5809084-middle.png)
Simple navigation through the Playwright Doc website

@specflowPlaywrightSkeleton
Scenario: Navigating through the Playwright website
	Given a user that navigates to the website
	And he clicks on the dotnet doc option
	And he clicks on the get started button
	Then the installation instructions should be available