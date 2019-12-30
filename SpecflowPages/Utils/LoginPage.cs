using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Utils
{
  public class LoginPage
    {
        public static void LoginStep()
        {
            CommonMethods.ExtentReports();
            //extent Reports
            CommonMethods.test = CommonMethods.extent.StartTest("Login Test");

            Driver.NavigateUrl();
            Thread.Sleep(1000);

            //Enter Url
            Driver.driver.FindElement(By.XPath("//a[@class='item']")).Click();

            //Enter Username
            Driver.driver.FindElement(By.XPath("//input[@name='email']")).SendKeys("tauropreema2018@gmail.com");
        
            //Enter password
            Driver.driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("iandsilva");
            Thread.Sleep(1000);
            try
            {
                //Click on Login Button
                Driver.driver.FindElement(By.XPath("//button[@class='fluid ui teal button']")).Click();
                if (Driver.WaitForElementDisplayed(Driver.driver, By.XPath("//a[contains(text(),'Mars Logo')]"), 60))
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login failed");
                }
            }
            catch(NoSuchElementException)
            {
                Console.WriteLine("Login failed");
            }

            //string msg = "Add New Job";
            //string Actualmsg = Driver.driver.FindElement(By.XPath("//*[@id='addnewjob']")).Text;

            //if (msg == Actualmsg)
            //{
            //Console.WriteLine("Test Passed");
            //CommonMethods.ExtentReports();
            //Thread.Sleep(500);
            //test = CommonMethods.extent.StartTest("Login with valid data");
            //Thread.Sleep(1000);
            //CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
            //SaveScreenShotClass.SaveScreenshot(Driver.driver, "HomePage");
            //}
            //else
            //{
            //Console.WriteLine("Test Failed");
            //CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            //}
        }

    }
}
