using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    /// <summary>
    /// klasa kupa
    /// </summary>
	internal class BasePage
	{
		public BasePage(IWebDriver driver)
		{
			Driver = driver;
		}

		protected IWebDriver Driver { get; set; }


	}
}
