using System;
using OpenQA.Selenium;


namespace Project1
{
	internal class ContactPage : BasePage
	{
		public ContactPage(IWebDriver driver) : base(driver) {}

        public IWebElement ContactUsDiv => Driver.FindElement(By.Id("contact-link"));

        public IWebElement MailForm => Driver.FindElement(By.Id("email"));

		public IWebElement OrderReference => Driver.FindElement(By.Id("id_order"));

		public IWebElement MessageForm => Driver.FindElement(By.Name("message"));

		public IWebElement ClickSendButton => Driver.FindElement(By.Id("submitMessage"));

		public IWebElement SelectSubjectHeading => Driver.FindElement(By.Id("id_contact"));

        internal void ClickContactUs()
        {
            ContactUsDiv.Click();
        }

        internal void GoToWebiste2()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }



        /*internal void GoToContactWebsite()
		{
			Driver.Manage().Window.Maximize();
			Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");
		}
        */



        internal void ChoseSubjectHeading(string subjectHeading)
		{
			SelectSubjectHeading.SendKeys(subjectHeading);
		}

		internal void WriteMail(string mailAddress)
		{
			MailForm.SendKeys(mailAddress);
		}

		internal void WriteOrderReference(string orderReference)
		{
			OrderReference.SendKeys(orderReference);
		}

		internal void WriteMessage(string messageText)
		{
			MessageForm.SendKeys(messageText);
			ClickSendButton.Click();

		}

		
	}

	
}