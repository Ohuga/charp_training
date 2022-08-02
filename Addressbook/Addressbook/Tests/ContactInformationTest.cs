using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
           AddressData fromTable = app.Address.GetContactInformationFromTable(0);
           AddressData fromForm = app.Address.GetContactInformationFromEditForm(0);
            // verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.Email, fromForm.Email);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
        [Test]
        public void TestContactInformation2()
        {
            String fromProperty = app.Address.GetContactInformationFromProperty(0);
            AddressData fromForm = app.Address.GetContactInformationFromEditForm(0);
            string all = fromForm.All;
            // verification
            Assert.AreEqual(fromProperty, all);
        }
    }
}
    

