using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddRemoveContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
            //var group = GroupData.GetAll()[0];
            //var oldList = group.GetAddresses();
            //var address = oldList[0];
            //app.Address.RemoveAddressFromGroup(address, group);

            //var newList = group.GetAddresses();
            //oldList.Remove(address);
            //oldList.Sort();
            //newList.Sort();
            //Assert.AreEqual(oldList, newList);
            var groups = GroupData.GetAll();
            if (!groups.Any())
                app.Groups.AddIfEmpty();
            var targetGroup = groups.FirstOrDefault(g => g.GetAddresses().Any());
            if (targetGroup == default)
            {
                TestAddingContactToGroup();
                targetGroup = groups.FirstOrDefault(g => g.GetAddresses().Any());
                Assert.NotNull(targetGroup);
            }
            var oldList = targetGroup.GetAddresses();
            var address = oldList[0];
            app.Address.RemoveAddressFromGroup(address, targetGroup);

            var newList = targetGroup.GetAddresses();
            oldList.Remove(address);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

        }

        [Test]
        public void TestAddingContactToGroup()
        {
            //GroupData group = GroupData.GetAll()[0];
            //List<AddressData> oldList = group.GetAddresses();
            //AddressData address = AddressData.GetAll().Except(oldList).First();

            ////actions
            //app.Address.AddAddressesToGroup(address, group); //????


            //List<AddressData> newList = group.GetAddresses();
            //oldList.Add(address);
            //newList.Sort();
            //oldList.Sort();

            //Assert.AreEqual(oldList, newList);

            app.Address.AddIfEmptyList();
            app.Groups.AddIfEmpty();

            var addresses = app.Address.GetAddressList();
            var groups = app.Groups.GetGroupList();

            AddressData targetAddress = null;
            GroupData targetGroup = null;
            var found = false;
            foreach (var address in addresses)
            {
                foreach (var group in groups)
                {
                    if (!group.GetAddresses().Contains(address))
                    {
                        targetAddress = address;
                        targetGroup = group;
                        found = true;
                        break;
                    }                    
                }
                if (found) break;
            }
            if (!found)
            {
                app.Address.AddAddress(new AddressData() { Lname = "123", Fname = "321" });
                var tmpAddresses = app.Address.GetAddressList();
                targetAddress = tmpAddresses.Except(addresses).First();
                targetGroup = groups[0];
            }
            var oldList = targetGroup.GetAddresses();
            app.Address.AddAddressesToGroup(targetAddress, targetGroup);
            List<AddressData> newList = targetGroup.GetAddresses();
            oldList.Add(targetAddress);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }
}
