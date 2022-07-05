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
            GroupData group = new GroupData("111")
            {
                Header = "111",
                Footer = "111"
            };
            
            app.Groups.Create(group);
        }
        [Test]
        public void EmptyGroupCreation()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group); 
        }
    }
}
