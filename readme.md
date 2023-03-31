# specflow-browserstack
[SpecFlow](http://www.specflow.org/) Integration with BrowserStack.

![BrowserStack Logo](https://d98b8t1nnulk5.cloudfront.net/production/images/layout/logo-header.png?1469004780)

<img src ="http://www.specflow.org/media/specflow_logo.png" height = "122">

## Setup
* Clone the repo
* Open the solution `SpecFlow_BrowserStack.sln` in Visual Studio.
* Build the solution
* Update `browserstack.yml` file with your [BrowserStack Username and Access Key](https://www.browserstack.com/accounts/settings)

### Running your tests from CLI
* To run the test suite having cross-platform with parallelization, dotnet test --filter "Category=sample-test"
* To run local tests, dotnet test --filter "Category=sample-local-test"
### Running your tests from Test Explorer
- To run a parallel tests, run test with fixture `sample-test`
- To run local tests, run test with fixture `sample-local-test`

 Understand how many parallel sessions you need by using our [Parallel Test Calculator](https://www.browserstack.com/automate/parallel-calculator?ref=github)

## Integrate your test suite

This repository uses the BrowserStack SDK to run tests on BrowserStack. Follow the steps below to install the SDK in your test suite and run tests on BrowserStack:

* Create sample browserstack.yml file with the browserstack related capabilities with your [BrowserStack Username and Access Key](https://www.browserstack.com/accounts/settings) and place it in your root folder.
* Add nuget library BrowserStack.TestAdapter
```sh
dotnet add BrowserStack.TestAdapter
```
* Build project `dotnet build`

## Notes
* You can view your test results on the [BrowserStack automate dashboard](https://www.browserstack.com/automate)
* To test on a different set of browsers, check out our [platform configurator](https://www.browserstack.com/automate/c-sharp#setting-os-and-browser)
* You can export the environment variables for the Username and Access Key of your BrowserStack account

  ```
  export BROWSERSTACK_USERNAME=<browserstack-username> &&
  export BROWSERSTACK_ACCESS_KEY=<browserstack-access-key>
  ```

## Additional Resources
* [Documentation for writing automate test scripts in C#](https://www.browserstack.com/automate/c-sharp)
* [Customizing your tests on BrowserStack](https://www.browserstack.com/automate/capabilities)
* [Browsers & mobile devices for selenium testing on BrowserStack](https://www.browserstack.com/list-of-browsers-and-platforms?product=automate)
* [Using REST API to access information about your tests via the command-line interface](https://www.browserstack.com/automate/rest-api)
