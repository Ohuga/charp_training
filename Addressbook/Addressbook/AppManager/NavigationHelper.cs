using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/edit.php");
        }
        public void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.Navigate().GoToUrl("http://localhost/addressbook/group.php");

        }

        //address
        public void GoToNewAdd()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnToAddressPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
