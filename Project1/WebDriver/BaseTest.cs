using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
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



		#region Properties

		/// <summary>
		/// Pages instance
		/// </summary>
		public Pages pages { get; private set; }

		/// <summary>
		/// Driver instance
		/// </summary>
		protected IWebDriver Driver { get; set; }


		#region Constructors
		public BaseTest(IWebDriver driver)
		{
			Driver = driver;
		}
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
