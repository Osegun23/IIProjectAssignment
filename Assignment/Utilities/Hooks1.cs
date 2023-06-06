using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Assignment.Utilities
{
    [Binding]
    public class Hooks1

        //This is where the selenium webdriver is initiated, that will be used across the project
    {
        public static IWebDriver driver;

        // This is where i set up the before method scenario where the chrome driver is
        // initiated from by selenium and the page is also set to be maximized

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            
        }

        //After Scenario is when all the automation is done and the browser should be shut down 
        //But i commented it out so you can see the whole process when its done.

        [AfterScenario]
        public void AfterScenario()
        {
            //driver.Quit();
        }
    }
}