using Assignment.Utilities;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.FedCm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.PageObject
{
    class HomePage
    {
        

        IWebDriver driver;
        public HomePage()
        {
            /*The Webdriver is called from the hooks file here to give life to the entire page object folder
            Also Implicit Wait is set so as to give time for the webpage to fully load before the begin of automation.*/

            driver = Hooks1.driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        /*This is where all the WebElements and Locators are saved
        My choice of locators depended on the level of transversing between child and parent locators
        The variable name is linked with the creation of the methods that will be seen below.*/
        

        IWebElement CompanyName => driver.FindElement(By.XPath("//div[@id='root']/div/header/div/a/span"));
        IWebElement AcceptCookies => driver.FindElement(By.XPath("//*[@id='chakra-modal-6']/footer/div/button"));
        IWebElement ServicesMenu => driver.FindElement(By.XPath("(//div[@class='ii-70qvj9'])[1]"));
        IWebElement Accounts => driver.FindElement(By.CssSelector("#navigationItemServices div div:nth-child(1) span"));
        IWebElement AccountType => driver.FindElement(By.XPath("(//*[text()='Trading Account'])[1]"));

        /*This is probably the only Locator that i needed to explain,
        I created a Webelement that is generic for the whole link in the account field
        so maybe if the locator for trading account is changed or maybe another functionality is added
        And the link is changed from that location, then only trading account will be clicked 
        And if another account is to be clicked, all i have to do is change the name in the method without changing the locator.*/
        IList<IWebElement> AccountOptions => driver.FindElements(By.CssSelector("li[class='ii-1ai24k'] a"));
        IWebElement TradingAccount => driver.FindElement(By.XPath("//*[@id='root']/div/main/div/div/div[2]/div[2]/div/div[1]/div/div/div[1]/h1"));


        /*This is the first method because i had to call the website from the feature file
        Since the method name is below, the method name will be needed in the steps definition file to give life to the whole project.*/
        
        public void NavigateToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        //This is the method for accepting cookies on the webpage

        public void CookieAcceptance()
        {
            AcceptCookies.Click();
        }

        /*My first assertion is to confirm that after i land on the page
        if the company name is displayed on the page.*/
        public bool IsCompanyNameDisplayed()
        {
            return CompanyName.Displayed;
        }

        /*for this i had to grab the Services text in the menu to confirm that 
        i am seeing Services on the top nav bar
        I also used another type of assertion here, just to write on the console.*/
        public void ProductType()
        {
            String ExpectedText = "Services";
           string ActualText =  ServicesMenu.Text;
            if (ActualText == ExpectedText)
            {
                Console.WriteLine("Text verification passed!");
            }
            else
            {
                Console.WriteLine("Text verification failed!");
            }

        }

        //This method is to click on the service menu to show the drop down
        

        public void ClickOnServiceButton()
        {
            ServicesMenu.Click();
        }
        //This assertion is also ot show that i am on the accounts link
        public bool IsAccountDisplayed()
        {
            return Accounts.Displayed;
        }
        //This assertion is to show that there is Trading Account in the account link
        public void TypeOfAccount()
        {
            String account = "Trading Account";
            String productName = AccountType.Text;
            Console.WriteLine(productName);
            Assert.AreEqual(account, productName);


        }

        /*This is the method i created for the click on the trading account
        This is a generic method that if i needed to click any link in the services dropdown
        All i have to do is change the name in the method and the link will be clicked without changing locators.*/
        public void IClickedOnTradingAccount()
        {
            foreach (IWebElement AccountOption in AccountOptions)
            {
                if (AccountOption.Text == "Trading Account")
                {
                    AccountOption.Click();
                    break;
                }
            }
        }
        
        /*This is an assertion to show that i am on the trading page,
        i could have used a displayed method but i just used another*/

        public void OnTradingAccountPage()
        {
            String expectedPageName = "Trading Account";
            String pageName = TradingAccount.Text;
            Console.WriteLine(pageName);
            Assert.AreEqual(expectedPageName,pageName);

        }

        //This is also to assert the URl 
        public void changeInURL()
        {
            string expectedUrl = "https://www.ii.co.uk/ii-accounts/trading-account";
            string currentUrl = driver.Url;

            Assert.AreEqual(expectedUrl, currentUrl);
        }


    }
}
