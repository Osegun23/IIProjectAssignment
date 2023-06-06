using Assignment.PageObject;
using Assignment.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Assignment.StepDefinitions
{
    [Binding]
    public class IterationStepDefinitions
    {
        /*Just as the situation for the Trading account, the object "iterationPage"
        was created from the class "IterationPage".*/

        public IWebDriver driver = Hooks1.driver;
        IterationPage iterationpage;

        // Then the "iterationPage" object will be used to call the methods from the page object folder
        public IterationStepDefinitions() 
        {
            iterationpage = new IterationPage();

        }

        /*In this Instance, the "iterationPage" is used to call the method i used for the first Iteration
        and the same logic goes for the second and third iteration*/

        [Then(@"I Iterate over the First Section")]
        public void ThenIIterateOverTheFirstSection()
        {
            iterationpage.FirstIteration();
        }


        [Then(@"I Iterate over Second Section")]
        public void ThenIIterateOverSecondSection()
        {
            iterationpage.SecondIteration();
        }


        [Then(@"i Iterate over the Third Section")]
        public void ThenIIterateOverTheThirdSection()
        {
            
            iterationpage.ThirdIteration();
        }
    }
}
