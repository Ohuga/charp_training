using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
            var group = GroupData.GetAll()[0];
            var oldList = group.GetAddresses();
            var address = oldList[0];
            app.Address.RemoveAddressFromGroup(address, group);

            var newList = group.GetAddresses();
            oldList.Remove(address);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<AddressData> oldList = group.GetAddresses();
            AddressData address = AddressData.GetAll().Except(oldList).First();

            //actions
            app.Address.AddAddressesToGroup(address, group); //????


            List<AddressData> newList = group.GetAddresses();
            oldList.Add(address);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }
    }
}
