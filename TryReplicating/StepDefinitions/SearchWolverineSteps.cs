using Coypu;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TryReplicating.LIB;

namespace TryReplicating.StepDefinitions
{
    [Binding]
    public class SearchWolverineSteps
    {
        private readonly BrowserSession _browser;
        
        public SearchWolverineSteps(BrowserSession browser)
        {
            _browser = browser;
        }

        [Given(@"I am on the '(.*)' page")]
        public void GivenIAmOnThePage(string subUrl)
        {
            _browser.Visit(subUrl);
        }
        
        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string searchCharacter)
        {
            _browser.FindId("search", UICommon.Wait).Click();
            _browser.FindXPath("//input[@class='typeahead__input']", UICommon.Wait).FillInWith(searchCharacter, UICommon.Wait).SendKeys(Keys.Enter, UICommon.Wait);
        }
        
        [Then(@"I can view the character details")]
        public void ThenICanViewTheCharacterDetails()
        {
            _browser.FindXPath("//div[@class='search-list__results-count']", UICommon.Wait).Text.Should().Contain("RESULTS");
        }
    }
}
