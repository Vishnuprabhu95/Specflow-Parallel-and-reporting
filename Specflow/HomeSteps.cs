
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace Test
{

    [Binding]
    public sealed class HomeStep
    {
        IWebDriver driver;


        [Given(@"the user hits amazon home page")]
        public void GivenTheUserHitsAmazonHomePage()
        {
            driver = new ChromeDriver(); 
            driver.Navigate().GoToUrl("https://www.amazon.in/");
        }

        [Then(@"the user is on amazon page")]
        public void ThenTheUserIsOnAmazonPage()
        {
            Assert.IsTrue(driver.Title.Contains("Amazon"),"Amazon error");
        }

        [Given(@"the user hits flipkart home page")]
        public void GivenTheUserHitsFlipkartHomePage()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.flipkart.com/");
        }

        [Then(@"the user is on flipkart page")]
        public void ThenTheUserIsOnFlipkartPage()
        {
            Assert.IsTrue(driver.Title.Contains("Online Shopping Site for Mobiles, Electronics, Furniture, Grocery, Lifestyle, Books &amp; More. Best Offers"),"Flipkart error");
        }


        [AfterScenario]
        public void tearDown()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
