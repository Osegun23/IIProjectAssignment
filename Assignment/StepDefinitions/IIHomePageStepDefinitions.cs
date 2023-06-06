using Assignment.PageObject;
using Assignment.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Assignment.StepDefinitions
{
    /*The binding here means the feature file is binding to this step definition
    the step definition is created from the feature file.*/
    

    [Binding]
    public class IIHomePageStepDefinitions
    {
        /*I called the driver also in the step definitions incase i need to call any driver method in here*/

        public IWebDriver driver = Hooks1.driver;

        /*This is the step where i begin to connect the page object folder to the step definition folder
        Homepage is the folder name for the page object in this instance.*/

        HomePage homePage;

        /*All i did here we create a class for the Homepage and then generate the object 
        The Object "homepage" generated is used to call the method created from the page object folder*/
        public IIHomePageStepDefinitions()
        {
             homePage = new HomePage();
        }

        /*This is where i begin to use the object created "homepage" to call all the methods i have created from the page objected folder
        In this Instance, the object homepage is used to call the method i used to 
        launch the URL from the page object which is NavigateToURL from the first method*/

        [Given(@"I navigate to ""([^""]*)""")]
        public void GivenINavigateTo(string url)
        { 

            homePage.NavigateToURL(url);
        }

        [When(@"I accept the cookie settings")]
        public void WhenIAcceptTheCookieSettings()
        {
            homePage.CookieAcceptance();
        }


        [Then(@"The company name should be on Home Page")]
        public void ThenTheCompanyNameShouldBeOnHomePage()
        {
           Assert.That(homePage.IsCompanyNameDisplayed());
        }

        [Then(@"I look at the Top Menu i should see Services")]
        public void ThenILookAtTheTopMenuIShouldSeeServices()
        {
            homePage.ProductType();
        }

        [When(@"I click on Services")]
        public void WhenIClickOnServices()
        {
            homePage.ClickOnServiceButton();
        }

        [Then(@"I should see the Accounts under Services drop down")]
        public void ThenIShouldSeeTheAccountsUnderServicesDropDown()
        {
            Assert.That(homePage.IsAccountDisplayed);
        }

        [Then(@"Under the Accounts i should see Trading account")]
        public void ThenUnderTheAccountsIShouldSeeTradingAccount()
        {
            homePage.TypeOfAccount();
        }

        [When(@"I click on Trading account")]


        public void WhenIClickOnTradingAccount()
        {
            homePage.IClickedOnTradingAccount();
        }

        [Then(@"I should see the Trading account page")]
        public void ThenIShouldSeeTheTradingAccountPage()
        {
            
            homePage.OnTradingAccountPage();
        }

        [Then(@"I should see the change in url")]
        public void ThenIShouldSeeTheChangeInUrl()
        {
            homePage.changeInURL();
        }




    }
}
