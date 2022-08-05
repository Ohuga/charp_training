using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddressTestBase : AuthTestBase
    {
        [TearDown]
        public void TearDown()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                var fromUI = app.Address.GetAddressListFromUI();
                var fromDB = AddressData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
