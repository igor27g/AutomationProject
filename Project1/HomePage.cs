using System;
using OpenQA.Selenium;

namespace Project1
{
	internal class HomePage : BasePage
	{
		

		public IWebElement ClickContactUsElement { get; private set; }

		public IWebElement SearchElement => Driver.FindElement(By.Id("search_query_top"));

		public IWebElement SearchIconElement => Driver.FindElement(By.Name("submit_search"));

		public HomePage(IWebDriver driver) : base(driver){}

		internal void GoToWebsite()
		{
			Driver.Manage().Window.Maximize();
			Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");			
		}


		internal void FillSearch(string clothes)
		{
			SearchElement.SendKeys(clothes);
			SearchIconElement.Click();
		}

		internal void ClickContactUs()
		{
			ClickContactUsElement = Driver.FindElement(By.ClassName("//*[@id='contact - link']/a"));
			//#contact-link > a
			//(By.XPath("//[@id='contact-link']/a"));
			////*[@id="contact-link"]/a
			/////*[@id="contact-link"]/a
		}

		internal void FindContactUs()
		{
			ClickContactUsElement.Click();
		}


	}
}