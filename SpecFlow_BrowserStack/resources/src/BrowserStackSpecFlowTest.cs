using System;
using TechTalk.SpecFlow;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SpecFlowBrowserStack
{
	[Binding]
	public class BrowserStackSpecFlowTest
	{
		private FeatureContext _featureContext;
		private ScenarioContext _scenarioContext;

		public static ThreadLocal<IWebDriver> ThreadLocalDriver = new ThreadLocal<IWebDriver>();
		private static readonly ILog log = LogManager.GetLogger(typeof(BrowserStackSpecFlowTest));

		public BrowserStackSpecFlowTest(FeatureContext featureContext, ScenarioContext scenarioContext)
		{
			_featureContext = featureContext;
			_scenarioContext = scenarioContext;
		}


		[BeforeScenario]
		public static void Initialize(ScenarioContext scenarioContext)
		{
			ChromeOptions capabilities = new ChromeOptions();
			ThreadLocalDriver.Value = new RemoteWebDriver(new Uri("https://hub.browserstack.com/wd/hub/"),capabilities);
		}


		[AfterScenario]
		public static void TearDown(ScenarioContext scenarioContext)
		{
			Shutdown();
		}

		protected static void Shutdown()
		{
			if (ThreadLocalDriver.IsValueCreated)
			{
				ThreadLocalDriver.Value?.Quit();
			}
		}
	}
}
