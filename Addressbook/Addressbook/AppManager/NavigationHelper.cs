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
            if (driver.Url == "http://localhost/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
        }

        public void GoToGroupPage()
        {
            if (driver.Url ==  "http://localhost/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
            driver.Navigate().GoToUrl("http://localhost/addressbook/group.php");
        }

        //address
        public void GoToAddressPage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook");
        }
        public void GoToNewAdd()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        
    }
}
