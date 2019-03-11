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
	public class Tests
	{
		



		#region properties       
		private IWebDriver Driver { get; set; }
		internal TestUser NewTestUser { get; private set; }
		#endregion

		#region Methods
		[TestMethod]
		[Description("Test to check that searchbar working")]
		public void TestSearch()
		{
	
			var homePage = new HomePage(Driver);			
			homePage.GoToWebsite();
			homePage.FillSearch(NewTestUser.wordSearch);
			Assert.IsTrue(Driver.Url.ToLower().Contains("t-shirt&submit_search"));
			
		}

		
		[TestMethod] 
		public void TestContactPage()
		{
        
            var contactPage = new ContactPage(Driver);

            contactPage.GoToWebsite();
            contactPage.ClickContactUs();
			Assert.IsTrue(Driver.Url.ToLower().Contains("controller=contact"));
			contactPage.ChoseSubjectHeading(NewTestUser.subjectHeading);
			contactPage.WriteMail(NewTestUser.mailAddress);
			contactPage.WriteOrderReference(NewTestUser.orderReference);			
			contactPage.WriteMessage(NewTestUser.messageText);
			
			string successMessage = Driver.FindElement(By.ClassName("alert-success")).Text;
			Assert.IsTrue(successMessage.Contains("Your message has been successfully sent to our team."));
		



		}

		[TestMethod]
		public void TestSiggInPage()
		{
			var signInPage = new SignInPage(Driver);

			signInPage.GoToWebsite();
			signInPage.ClickSignIn();
			signInPage.EmailAddressWrite(NewTestUser.mailAddress);
			

		}
		#endregion

		#region Setup
		/// <summary>
		/// Method to initialize browser
		/// </summary>
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
		#endregion

		#region Webdriver
		/// <summary>
		/// WebDriver
		/// </summary>
		/// <returns></returns>
		private IWebDriver GetChromeDriver()
		{
			var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			return new ChromeDriver(outPutDirectory);
		}
		#endregion

		#region CleanUp
		[TestCleanup]
		public void CleanUpAfterTest()
		{
			Thread.Sleep(3000);
			Driver.Close();			
			Driver.Quit();
		}
		#endregion



	}


}
