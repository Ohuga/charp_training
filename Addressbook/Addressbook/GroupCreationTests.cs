using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       

        [Test]
        public void GroupCreation()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountDate("admin", "secret"));
            navigator.GoToGroupPage();
            groupHelper.InitNewGroupCreation();
            GroupDate group = new GroupDate("111")
            {
                Header = "111",
                Footer = "111"
            };
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
            //driver.FindElement(By.LinkText("Logout")).Click();
            //driver.FindElement(By.Name("user")).Clear();
            //driver.FindElement(By.Name("user")).SendKeys("admin");
            //driver.FindElement(By.Name("pass")).Clear();
            //driver.FindElement(By.Name("pass")).SendKeys("secret");
        } 
    }
}
