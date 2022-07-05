using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    internal class AddressModificationsTests: TestBase
    {
        [Test]
        public void AddressModificationTest()
        {
            app.Address.GoToAddressPage()
                .InitAddressModification(1)
                .FillNewAdd(new AddressData { Fname = "234", Lname = "345" })
                .SubmitAddressModification()
                .ReturnToAddressPage();

        }
    }
}
