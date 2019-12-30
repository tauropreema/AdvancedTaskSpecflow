using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class EditShareSkillSteps
    {
        [Given(@"I have Loggined and Clicked on manage listing")]
        public void GivenIHaveLogginedAndClickedOnManageListing()
        {
            //Click on Manage Listing Button
            IWebElement ClickManageListing = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));
            ClickManageListing.Click();


        }

        [Given(@"I have Clicked on Edit and Edited details")]
        public void GivenIHaveClickedOnEditAndEditedDetails()
        {
            CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "ShareSkills");


            //Click on Edit nad Adde details
            IWebElement ClickEditButton = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
            ClickEditButton.Click();
            //EditTitle

            IWebElement EditTitle = Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
            EditTitle.Clear();
            EditTitle.SendKeys(CommonMethods.ExcelLib.ReadData(2, "EditTitle"));




            //EditDesription
            IWebElement EditDesription = Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
            EditDesription.Clear();

            EditDesription.SendKeys(CommonMethods.ExcelLib.ReadData(2, "EditDescription"));


        }

        [When(@"I press Save")]
        public void WhenIPressSave()
        {
            //ClickSave
            IWebElement ClickSaveEdit = Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]"));
            ClickSaveEdit.Click();
        }


        [Then(@"the Shareskills should be added")]
        public void ThenTheShareskillsShouldBeAdded()
        {
            //Validation
            //Validatetitle
            string Expectedtitle = "Automation with Selenium";
            IWebElement Validatetitle = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[3]"));
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Skill Details");

                Thread.Sleep(1000);
                if (Expectedtitle == Validatetitle.Text)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "EditTitle Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Edit Shareskills added");
                    Console.WriteLine("Success");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edit Share Skill Unsuccessful");
                    Console.WriteLine("Success");
                }
            }
            
            
            catch (Exception ex)
            {
            Console.WriteLine(ex);
            }

        }
    }
    }

