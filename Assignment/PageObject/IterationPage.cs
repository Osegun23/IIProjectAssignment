using Assignment.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment.PageObject
{
    class IterationPage
    {
        /*Just as i have explained the scenario of the Homepage, the same logic applies here
        in this folder, the first  steps is used from the Homepage scenario because i dont have to repeat the same codes.*/
        


        IWebDriver driver;
        public IterationPage()
        {
            driver = Hooks1.driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        /*Here i created a webelement for the 3 sections of the headers
        The second and third section contains multiple elements so i had to use a generic locator for them to iterate over them
        Just as i did in the clicking of trading account. */
        IWebElement FirstIterationFrame => driver.FindElement(By.XPath("//div[@id='root']/div/header/div/a/span"));
        IList<IWebElement> ThirdIterationFrames => driver.FindElements(By.CssSelector("div[class='ii-wvpcmz'] div"));
        IList<IWebElement> SecondIterationFrames => driver.FindElements(By.XPath("//*[@id='root']/div/header/div/nav/ul/li"));

        //For the first section, just one element was present so i compared the text to the text that was grabbed from the locator

        public void FirstIteration()
        {
            string Output = "Interactive Investor";
            string HeaderListOne = FirstIterationFrame.Text;
            Console.WriteLine(HeaderListOne);
            Assert.AreEqual(Output, HeaderListOne);

        }

        /*For this section, i created an array for the headers, also i crated a for loop with the locators in the section
        the logic was that after grabbing all the text in this section, it should assert against the array that was created
        if it contains any of the strings listed.
        If it does, then the test will pass, if not, it will fail.*/

        public void SecondIteration()
        {
            String[] ExpectedOutputs = { "Services", "Pensions", "Investments", "Help & learning", "News" };
            foreach (IWebElement SecondIterationFrame in SecondIterationFrames)
            {
                string HeaderListsTwo = SecondIterationFrame.Text;

                Console.WriteLine(HeaderListsTwo);
                foreach (string ExpectedText in ExpectedOutputs)
                {
                    if (HeaderListsTwo.Contains(ExpectedText))
                    {
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        Assert.IsFalse(false);
                    }
                }
            }
        }

        /*For this section, i created an array for the headers, also i crated a for loop with the locators in the section
        the logic was that after grabbing all the text in this section, it should assert against the array that was created
        if it contains any of the strings listed.
        If it does, then the test will pass, if not, it will fail
        this contains just 3 headers, so they were checked against what was grabbed*/

        public void ThirdIteration() 
        {

            String[] ExpectedTexts = { "Search", "Log in", "Sign up" };

            foreach (IWebElement ThirdIterationFrame in ThirdIterationFrames)
            {
                string HeaderListsThree = ThirdIterationFrame.Text;

                Console.WriteLine(HeaderListsThree);

                foreach (string ExpectedText in ExpectedTexts)
                {
                    if(HeaderListsThree.Contains(ExpectedText))
                    {
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        Assert.IsFalse(false);
                    }
                }

            }
            

        }

        




    }
}
