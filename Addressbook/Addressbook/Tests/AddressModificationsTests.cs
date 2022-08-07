using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    internal class AddressModificationsTests: AddressTestBase
    {
        [Test]
        public void AddressModificationTest()
        {
            app.Address.GoToAddressPage()
            .AddIfEmptyList();
            var old = app.Address.GetAddressList();
            var targetAddress = old[0];
            var newAddr = new AddressData { Fname = "234", Lname = "345" };
            app.Address.InitAddressModificationById(targetAddress.Id)
            .FillNewAdd(newAddr)
            .SubmitAddressModification()
            .ReturnToAddressPage();

            targetAddress.Fname = newAddr.Fname;
            targetAddress.Lname = newAddr.Lname;
            //get current list
            var current = app.Address.GetAddressList();
            Assert.AreEqual(old, current);
            old.Sort();
            current.Sort();
            Assert.AreEqual(old, current);
         
        }
    }
}
