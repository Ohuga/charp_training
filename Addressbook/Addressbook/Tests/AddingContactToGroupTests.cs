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
