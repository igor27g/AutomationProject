using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    
	internal class BaseTest
	{
		

		public BaseTest(IWebDriver driver)
		{
			Driver = driver;
		}

		protected IWebDriver Driver { get; set; }


		internal void GoToWebsite()
		{
			Driver.Manage().Window.Maximize();
			Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
		}




	}
}
