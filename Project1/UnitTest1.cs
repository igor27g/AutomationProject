using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Project1
{
	[TestClass]
	[TestCategory("SampleApplicationOne")]
	public class UnitTest1 
	{
        

        private IWebDriver Driver { get; set; }
		internal TestUser NewTestUser { get; private set; }

		[TestMethod]
		[Description("Test to check that searchbar working")]
		public void TestMethod1()
		{
	
			var homePage = new HomePage(Driver);			
			homePage.GoToWebsite();
			homePage.FillSearch(NewTestUser.wordSearch);
			
			
		}

		
		[TestMethod] 
		public void TestMethod2()
		{
        
            var contactPage = new ContactPage(Driver);

            contactPage.GoToWebsite();
            contactPage.ClickContactUs();     
			contactPage.ChoseSubjectHeading(NewTestUser.subjectHeading);
			contactPage.WriteMail(NewTestUser.mailAddress);
			contactPage.WriteOrderReference(NewTestUser.orderReference);
			contactPage.WriteMessage(NewTestUser.messageText);
		
		}

		[TestInitialize]
		public void Setup()
		{
			Driver = GetChromeDriver();
					
			NewTestUser = new TestUser();
			NewTestUser.mailAddress = "igor123@jmail.ovh";
			NewTestUser.orderReference = "123456789";
			NewTestUser.messageText = "TextMessage should be long and interesting";
			NewTestUser.subjectHeading = "Webmaster";
			NewTestUser.wordSearch = "T-shirt";

		}

		
		[TestCleanup]
		public void CleanUpAfterTest()
		{
			Thread.Sleep(3000);
			Driver.Close();			
			Driver.Quit();
		}
		
	
		private IWebDriver GetChromeDriver()
		{
			var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);			
			return new ChromeDriver(outPutDirectory);
		}

	}

}
