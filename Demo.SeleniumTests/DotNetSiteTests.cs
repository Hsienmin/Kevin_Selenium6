using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System; 
using System.Linq;

namespace Demo.SeleniumTests
{
    [TestClass]
    public class DotNetSiteTests
    {
        [TestMethod]
        public void TestGetStarted()
        {
            // Chrome Driver was manually downloaded from https://sites.google.com/a/chromium.org/chromedriver/downloads
            // parameter "." will instruct to look for the chromedriver.exe in the current folder

            //Run Google Chrome Driver with UI Visual
            //using (var driver = new ChromeDriver("."))

            var options = new ChromeOptions();
            options.AddArgument("headless");
            using (var driver = new ChromeDriver(".", options))            
                {

                driver.Navigate().GoToUrl("http://teamsportaldemo.azurewebsites.net/");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
                driver.FindElement(By.Name("email")).SendKeys("admin@altigen.com");
                driver.FindElement(By.Name("password")).SendKeys("222222");
                driver.FindElement(By.ClassName("MuiButton-label")).Click();

                // Get Started section is a multi-step wizard
                // The following sections will find the visible next step button until there's no next step button left
                //IWebElement nextLink = null;
                //do
                //{
                //    nextLink?.Click();
                //    nextLink = driver.FindElements(By.CssSelector(".step:not([style='display:none;']):not([style='display: none;']) .step-select")).FirstOrDefault();
                //} while (nextLink != null);

                // on the last step, grab the title of the step wich should be equal to "Next steps"
                //var lastStepTitle = driver.FindElement(By.CssSelector(".step:not([style='display:none;']):not([style='display: none;']) h2")).Text;

                // verify the title is the expected value "Next steps"
                // Assert.AreEqual(lastStepTitle, "Next steps");
            }
        }
    }
}