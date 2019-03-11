using System;
using System.Threading;
using OpenQA.Selenium;


namespace Project1
{
	internal class ContactPage : BaseTest
	{

		#region WebElements
		public IWebElement ContactUsDiv => Driver.FindElement(By.Id("contact-link"));

        public IWebElement MailForm => Driver.FindElement(By.Id("email"));

		public IWebElement OrderReference => Driver.FindElement(By.Id("id_order"));

		public IWebElement MessageForm => Driver.FindElement(By.Name("message"));

		public IWebElement ClickSendButton => Driver.FindElement(By.Id("submitMessage"));

		public IWebElement SelectSubjectHeading => Driver.FindElement(By.Id("id_contact"));

		

		#endregion

		#region Constructors
		public ContactPage(IWebDriver driver) : base(driver) { }
		#endregion

		#region Methods
		internal void ClickContactUs()
        {
            ContactUsDiv.Click();
        }


		internal void ChoseSubjectHeading(string subjectHeading)
		{
			Thread.Sleep(3000);
			SelectSubjectHeading.SendKeys(subjectHeading);
		}

		internal void WriteMail(string mailAddress)
		{
			MailForm.SendKeys(mailAddress);
			Thread.Sleep(3000);
		}

		internal void WriteOrderReference(string orderReference)
		{
			OrderReference.SendKeys(orderReference);
			Thread.Sleep(3000);
		}

		internal void WriteMessage(string messageText)
		{
			MessageForm.SendKeys(messageText);
			Thread.Sleep(3000);
			ClickSendButton.Click();
		}

		

		#endregion


	}


}