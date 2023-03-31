using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace SpecFlowBrowserStack
{
	[Binding]
	public class SampleTest

	{
		private readonly IWebDriver _driver;
		private string? productOnPageText;
		private string? productOnCartText;
		private bool? cartOpened;
		readonly WebDriverWait wait;

		public SampleTest()
		{
			_driver = BrowserStackSpecFlowTest.ThreadLocalDriver.Value;
			wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
		}

		[Given(@"I navigate to website")]
		public void GivenINavigatedTowebsite()
		{
            _driver.Navigate().GoToUrl("https://bstackdemo.com");
		}

		[Then(@"I should see title (.*)")]
		public void ThenIShouldSeeTitle(string title)
		{
			Thread.Sleep(5000);
			Assert.That(_driver.Title, Is.EqualTo(title));
		}
		
		[Then(@"I add product to cart")]
		public void ThenIAddProductToCart()
		{
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"1\"]/p")));
			productOnPageText = _driver.FindElement(By.XPath("//*[@id=\"1\"]/p")).Text;
			wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"1\"]/div[4]")));
			_driver.FindElement(By.XPath("//*[@id=\"1\"]/div[4]")).Click();
		}

		[When(@"I check if cart is opened")]
		public void ThenICheckIfCartIsOpened()
		{
			cartOpened = _driver.FindElement(By.XPath("//*[@class=\"float-cart__content\"]")).Displayed;
			Assert.That(cartOpened, Is.EqualTo(true));
		}

		[Then(@"I should see same product in cart")]
		public void ThenIShouldSeeSameProductInCart()
		{
			productOnCartText = _driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div/div[2]/div[2]/div[2]/div/div[3]/p[1]")).Text;
			Assert.That(productOnCartText, Is.EqualTo(productOnPageText));
		}
	}
}
