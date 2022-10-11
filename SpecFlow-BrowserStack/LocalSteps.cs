using System;
using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlow_BrowserStack
{
  [Binding]
  public class LocalSteps
  {
    private IWebDriver _driver;
    readonly BrowserStackDriver _bsDriver;

    public LocalSteps(ScenarioContext scenarioContext)
    {
      _bsDriver = (BrowserStackDriver)scenarioContext["bsDriver"];
    }

    [Given(@"I opened health check for (.*) and (.*)")]
    public void GivenIOpenedHealthCheck(string profile, string environment)
    {
      _driver = _bsDriver.Init(profile, environment);
      _driver.Navigate().GoToUrl("http://bs-local.com:45691/check");
    }
        
    [Then(@"I should see ""(.*)""")]
    public void ThenIShouldSee(string body)
    {
      Assert.That(_driver.PageSource, Does.Contain(body));
    }
  }
}
