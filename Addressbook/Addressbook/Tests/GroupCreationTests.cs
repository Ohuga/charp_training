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
            GroupDate group = new GroupDate("111")
            {
                Header = "111",
                Footer = "111"
            };
            
            app.Groups.Create(group);
        }
        [Test]
        public void EmptyGroupCreation()
        {

            GroupDate group = new GroupDate("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group); 
        }
    }
}
