using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Coypu;
using Coypu.Drivers.Selenium;
using BoDi;

namespace TryReplicating.Support
{
    [Binding]
    class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private BrowserSession _browser;
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Before()
        {
            var sessionConfiguration = new SessionConfiguration
            {
                AppHost = "https://www.marvel.com/"
            };
            sessionConfiguration.Driver = typeof(SeleniumWebDriver);
            sessionConfiguration.Browser = Coypu.Drivers.Browser.Chrome;
            _browser = new BrowserSession(sessionConfiguration);
            _browser.MaximiseWindow();
            _objectContainer.RegisterInstanceAs(_browser);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _browser.Dispose();
        }
    }
}
