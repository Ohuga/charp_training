using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddAddress : AuthTestBase
    {
        public static IEnumerable<AddressData> RandomAddressDataProvider()
        {
            List<AddressData> address = new List<AddressData>();
            for (int i = 0; i < 3; i++)
            {
                address.Add(new AddressData(GenerateRandomString(5), GenerateRandomString(5)));

            }
            return address;
        }
        public static IEnumerable<AddressData> ContactsDataFromXmlFile()
        {
            using (var fs = new FileStream("contacts.xml", FileMode.Open))
            {
                var contacts = new XmlSerializer(typeof(List<AddressData>)).Deserialize(fs) as List<AddressData>;
                return contacts;
            }
        }
        public static IEnumerable<AddressData> ContactsDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<AddressData>>(File.ReadAllText("contacts.json"));
        }

        [Test, TestCaseSource("ContactsDataFromXmlFile")]
        public void AddAddressTest(AddressData address)
        {
            app.Navigator.GoToNewAdd();

            List<AddressData> oldAddresses = app.Address.GetAddressList();

            app.Address.AddAddress(address);
            List<AddressData> newAddresses = app.Address.GetAddressList();

            Assert.AreEqual(oldAddresses.Count + 1, newAddresses);
            oldAddresses.Add(address);
            oldAddresses.Sort();
            newAddresses.Sort();
            Assert.AreEqual(oldAddresses, newAddresses);
            for (var i = 0; i < oldAddresses.Count; i++)
            Assert.AreEqual(oldAddresses[i], newAddresses[i]);
        }       

        [Test]
        public void AddEmptyAddress()
        {
            app.Navigator.GoToNewAdd();
            AddressData address = new AddressData("")
            {
                Fname = "",
                Lname = ""
            };
            app.Address
                .FillNewAdd(address)
                .SubmitNewAdd()
                .ReturnToAddressPage();
        }
    }
}
