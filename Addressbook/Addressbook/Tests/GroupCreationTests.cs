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
    public class GroupCreationTests : AuthTestBase
    {
       

        [Test]
        public void GroupCreation()
        {
            GroupData group = new GroupData("111")
            {
                Header = "111",
                Footer = "111"
            };

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups =  app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [Test]
        public void EmptyGroupCreation()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [Test]
        public void BadNameGroupCreation()
        {
            GroupData group = new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
