using OpenQA.Selenium;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class DeleteShareskillsSteps
    {
        [Given(@"I have Loggined and clicked on Manage Listing")]
        public void GivenIHaveLogginedAndClickedOnManageListing()
        {
            //Click on Manage Listing
            IWebElement ClickManageListing = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));
            ClickManageListing.Click();

        }
        
        [When(@"I press Delete")]
        public void WhenIPressDelete()
        {
            //Click on Delete Button
            //DeleteShareskill
            IWebElement DeleteShareSkill = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
            DeleteShareSkill.Click();
            

            //AlertDelete
            IWebElement AlertDelete = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
            AlertDelete.Click();
        }
        
        [Then(@"the Shareskill details should be deleted")]
        public void ThenTheShareskillDetailsShouldBeDeleted()
        {
            //Validation
            //ValidateDeleteShareSkill
            try
            {
                string ExpectedAfterdeletion = "You do not have any service listings!";
                //Start the Reports
                CommonMethods.ExtentReports();
                
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Skill Details");

                

                 IWebElement ValidateDeleteShareSkill = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/h3"));
                if (ExpectedAfterdeletion == ValidateDeleteShareSkill.Text)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Delete Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Delete Shareskills added");
                    Console.WriteLine("Success");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Delete Share Skill Unsuccessful");
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
