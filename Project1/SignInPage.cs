using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Project1
{
	class SignInPage : BaseTest
	{
		public IWebElement SignIn => Driver.FindElement(By.ClassName("header_user_info"));

		public IWebElement EmailAddress => Driver.FindElement(By.Id("email_create"));

		public IWebElement CreateAccountButton => Driver.FindElement(By.Id("SubmitCreate"));

		public SignInPage(IWebDriver driver) : base(driver) {}

		internal void ClickSignIn()
		{
			SignIn.Click();
		}
		
		internal void EmailAddressWrite(string mailAddress)
		{
			EmailAddress.SendKeys(mailAddress);
			Thread.Sleep(3000);
			CreateAccountButton.Click();
		}
	}
}
