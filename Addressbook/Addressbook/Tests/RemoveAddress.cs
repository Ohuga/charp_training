using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveAdd : AuthTestBase
    {
        [Test]
        public void RemoveAddresses()
        {
            app.Address.GoToAddressPage()
                .AddIfEmptyList();


            List<AddressData> oldAddresses = app.Address.GetAddressList();
            app.Address.RemoveAddress(1).GoToAddressPage();  
            List<AddressData> newAddresses = app.Address.GetAddressList();

            Assert.AreEqual(oldAddresses.Count - 1, newAddresses.Count);
            oldAddresses.RemoveAt(0);
            oldAddresses.Sort();
            newAddresses.Sort();
            Assert.AreEqual(oldAddresses, newAddresses);
            for (var i = 0; i < oldAddresses.Count; i++)
                Assert.AreEqual(oldAddresses[i], newAddresses[i]);


        }
    }
}



/*public void GroupRemovalTest()
{
    List<AddressData> old = app.Address.GetAddressList();

    app.RemoveAddress.Remove(0);

    Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

    List<GroupData> newGroups = app.Groups.GetGroupList();

    GroupData toBeRemoved = oldGroups[0];

    oldGroups.RemoveAt(0);
    Assert.AreEqual(oldGroups, newGroups);

    foreach (GroupData group in newGroups)
    {
        Assert.AreNotEqual(group.Id, toBeRemoved.Id);

    }*/
