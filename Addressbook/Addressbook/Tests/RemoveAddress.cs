using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveAdd : AddressTestBase
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
            oldAddresses.Sort();
            newAddresses.Sort();
            oldAddresses.RemoveAt(0);          
            
            Assert.AreEqual(oldAddresses, newAddresses);
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
