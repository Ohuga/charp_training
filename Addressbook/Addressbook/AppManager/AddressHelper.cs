using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class AddressHelper : HelperBase
    {
        public AddressHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public AddressHelper AddIfEmptyList()
        {
            if (GetSearchCount() == 0)
            {
                FillNewAdd(new AddressData { Fname = "1", Lname = "2" });
            }
            return this;
        }
        private int GetSearchCount()
        {
            return int.Parse(driver.FindElement(By.Id("search_count")).Text);
        }
        public AddressHelper SubmitNewAdd()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public AddressHelper FillNewAdd(AddressData address)
        {
            Type(By.Name("firstname"), address.Fname);
            Type(By.Name("lastname"), address.Lname);
            return this;
        }
        public AddressHelper ReturnToAddressPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public AddressHelper RemoveAddress(int p)
        {
            GoToAddressPage();
            SelectAddress(p);
            DeleteAddress();
            CloseWindow();
            return this;
        }

        public AddressHelper CloseWindow()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
        }

        public AddressHelper DeleteAddress()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public AddressHelper SelectAddress(int p)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/table/tbody/tr["+(p+1)+"]/td[1]/input")).Click();
            return this;
        }

        public AddressHelper GoToAddressPage()
        {
            //driver.Navigate().GoToUrl("http://localhost/addressbook");
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public AddressHelper SubmitAddressModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public AddressHelper InitAddressModification(int p)
        {
            //driver.FindElement(By.Name("edit")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/table/tbody/tr[" + (p + 1) + "]/td[8]/a")).Click();
            return this;
        }
    }
}
