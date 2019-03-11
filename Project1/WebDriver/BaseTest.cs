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

		#region Constructors
		public BaseTest(IWebDriver driver)
		{
			Driver = driver;
		}
		#endregion

		#region Properties
		protected IWebDriver Driver { get; set; }

		

		#endregion

		#region Methods
		internal void GoToWebsite()
		{
			Driver.Manage().Window.Maximize();
			Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
		}
		#endregion



	}
}
