using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    internal class AddressModificationsTests: AuthTestBase
    {
        [Test]
        public void AddressModificationTest()
        {
            app.Address.GoToAddressPage()
            .AddIfEmptyList();
            var old = app.Address.GetAddressList();
            var newAddr = new AddressData { Fname = "234", Lname = "345" };
            app.Address.InitAddressModification(1)
            .FillNewAdd(newAddr)
            .SubmitAddressModification()
            .ReturnToAddressPage();
   
            old[0].Fname = newAddr.Fname;
            old[0].Lname = newAddr.Lname;
            //get current list
            var current = app.Address.GetAddressList();
            Assert.AreEqual(old, current);
            old.Sort();
            current.Sort();
            for(var i = 0; i < old.Count; i++)
            Assert.AreEqual(old[i], current[i]);
         
        }
    }
}
