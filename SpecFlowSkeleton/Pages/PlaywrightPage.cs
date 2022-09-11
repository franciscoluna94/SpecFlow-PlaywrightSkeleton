﻿using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using SpecFlowSkeleton.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSkeleton.Pages
{
    public class PlaywrightPage
    {
        private readonly IConfiguration _configuration;
        private readonly ScenarioContext _scenarioContext;
        protected readonly IPage _page;

        public PlaywrightPage(ScenarioContext scenarioContext, IConfiguration configuration)
        {
            _scenarioContext = scenarioContext;
            _configuration = configuration;
            _page = _scenarioContext.Get<IPage>(Hooks.PageKey);
        }

        public async Task GotoAsync()
        {
            var url = _configuration[ConfigurationKeys.Url];
            await _page.GotoAsync(url);
        }

        public async Task WaitForUrlAsync(string url)
        {
            await _page.WaitForURLAsync(url);
        }

        public async Task ClickAsync(string selector)
        {
            await _page.Locator(selector).ClickAsync();
        }

        public async Task DispatchClickAsync(string selector)
        {
            await _page.Locator(selector).DispatchEventAsync("click");
        }

        public async Task IsVisibleAsync(string selector)
        {
            await _page.Locator(selector).IsVisibleAsync();
        }
    }
}
