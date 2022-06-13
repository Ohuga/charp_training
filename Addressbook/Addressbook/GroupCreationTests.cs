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
            GoToHomePage();
            Login(new AccountDate("admin", "secret"));
            GoToGroupPage();
            InitNewGroupCreation();
            GroupDate group = new GroupDate("111")
            {
                Header = "111",
                Footer = "111"
            };
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            //driver.FindElement(By.LinkText("Logout")).Click();
            //driver.FindElement(By.Name("user")).Clear();
            //driver.FindElement(By.Name("user")).SendKeys("admin");
            //driver.FindElement(By.Name("pass")).Clear();
            //driver.FindElement(By.Name("pass")).SendKeys("secret");
        } 
    }
}
