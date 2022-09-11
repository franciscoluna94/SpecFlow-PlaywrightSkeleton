using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowSkeleton.Support
{
    [Binding]
    public class Hooks
    {
        public static readonly string PageKey = "page";
        public static readonly string BrowserContextKey = "browserContext";
        public static bool IsAuthenticated;
        public static IBrowser browser;

        private readonly ScenarioContext _scenarioContext;
        private readonly IConfiguration _configuration;
        private readonly SecretClient _secretClient;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public Hooks(ScenarioContext scenarioContext, IConfiguration configuration, SecretClient secretClient, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _scenarioContext = scenarioContext;
            _configuration = configuration;
            _secretClient = secretClient;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [BeforeTestRun]
        public static async Task BeforeTests()
        {
            var playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false
                });
        }

        [AfterTestRun]
        public static async Task AfterTests()
        {
            await browser.CloseAsync();
            await browser.DisposeAsync();
        }

        [BeforeScenario]
        public async Task BeforeScenarios()
        {
            var browserContext = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                StorageStatePath = IsAuthenticated ? "state.json" : null
            });

            var page = await browserContext.NewPageAsync();

            _scenarioContext.Add(PageKey, page);
            _scenarioContext.Add(BrowserContextKey, browserContext);
        }

        [AfterScenario]
        public async Task AfterScenarios()
        {
            var broswerContext = _scenarioContext.Get<IBrowserContext>(BrowserContextKey);

            await browser.CloseAsync();
            if (_scenarioContext.TestError is not null)
            {
                _specFlowOutputHelper.WriteLine("Test failed");
            }
            else
            {
                _specFlowOutputHelper.WriteLine("Test without error");
            }

            await broswerContext.StorageStateAsync(new BrowserContextStorageStateOptions
            {
                Path = "state.json"
            });

            IsAuthenticated = true;            
        }

    }
}
