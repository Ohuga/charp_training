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
    public class GroupRemovalTests : AuthTestBase
    {      
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> newGroups = app.Groups.GetGroupList();

            app.Groups.AddIfEmpty().Remove(0);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
