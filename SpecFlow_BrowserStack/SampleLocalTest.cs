using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace SpecflowBrowserStack
{
	[Binding]
	public class SampleLocalTest

	{
		private readonly IWebDriver _driver;

		public SampleLocalTest()
		{
			_driver = BrowserStackSpecflowTest.ThreadLocalDriver.Value;
			new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
		}

		[Given(@"I navigate to website")]
		public void GivenINavigatedTowebsite()
		{
			_driver.Navigate().GoToUrl("http://bs-local.com:45454/");
		}

		[Then(@"title should contain `BrowserStack Local`")]
		public void ThenIShouldSeeTitle(string localString)
		{
			Thread.Sleep(5000);
			StringAssert.Contains("BrowserStack Local", _driver.Title);
		}
	}
}
