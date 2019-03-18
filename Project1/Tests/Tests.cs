using System;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Project1
{
	
	public class Tests
	{


		#region properties       
		/// <summary>
		///  WebDriver
		/// </summary>
		private IWebDriver Driver { get; set; }

		/// <summary>
		/// TestUser Class
		/// </summary>
		internal TestUser NewTestUser { get; private set; }

		/// <summary>
		/// Searchbar Class
		/// </summary>
		internal SearchBar TestSearchBar { get; private set; }
		#endregion



		#region Methods


		[Test(Description = "Test to checkt that searchbar working")]
		public void TestSearch()
		{

			var homePage = new HomePage(Driver);
			homePage.GoToWebsite();

			homePage.FillSearch(TestSearchBar.wordSearch);
			Assert.IsTrue(Driver.Url.ToLower().Contains("t-shirt&submit_search"));
			
		}


		[Test(Description = "Test to check sending message using contact us")]
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


		[Test(Description = "Test to check signInPage regestration")]
		public void TestSiggInPage()
		{
			var signInPage = new SignInPage(Driver);

			signInPage.GoToWebsite();
			signInPage.ClickSignIn();
			signInPage.EmailAddressWrite(NewTestUser.mailAddress);
			string buttonRegrestation = Driver.FindElement(By.XPath("//div[@class='submit']//span[1]")).Text;
			Assert.IsTrue(buttonRegrestation.Contains("Create an account"));
			

		}
		#endregion

		#region Setup
		/// <summary>
		/// Method to initialize browser
		/// </summary>

		[SetUp]
		public void Setup()
		{
			Driver = GetChromeDriver();


			/// <summary>
			/// TestUser Object
			/// </summary>
			NewTestUser = new TestUser();
			NewTestUser.mailAddress = "igor123@jmail.ovh";
			NewTestUser.orderReference = "123456789";
			NewTestUser.messageText = "TextMessage should be long and interesting";
			NewTestUser.subjectHeading = "Webmaster";

			/// <summary>
			/// Searchbar Object
			/// </summary>

			TestSearchBar = new SearchBar();
			TestSearchBar.wordSearch = "T-shirt";


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
		[TearDown]
		public void CleanUpAfterTest()
		{
			Thread.Sleep(3000);
			Driver.Close();			
			Driver.Quit();
		}
		#endregion



	}


}
