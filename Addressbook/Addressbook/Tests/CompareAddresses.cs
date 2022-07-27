using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace  WebAddressbookTests
{
    [TestFixture]
    public class CompareAddress : AuthTestBase
    {
        public List<AddressData> GetAddressList()
        {
            List <AddressData> addresses = new List <AddressData>();
            app.Navigator.GoToAddressPage();
            ICollection<IWebElement> elements = app.Navigator.GetCollection("entry");
            foreach(IWebElement element in elements)
            {
                ReadOnlyCollection < IWebElement > names = element.FindElements(By.TagName("td"));
                String lname = names[1].Text;
                String fname = names[2].Text;
                addresses.Add(new AddressData(fname,lname));
            }
            return addresses;
        }
        [Test]
        public void CompareAddressListTest()
        {
            //Get Address collection
            List<AddressData> oldList = GetAddressList();
            //Create new Address
            AddressData adress = new AddressData("Vasya", "Petrov");
            //Add new Address to Database
            app.Address.AddAddress(adress);
            //Get updated Address Collection
            List<AddressData> newList = GetAddressList();
            //Remove Addres from Data Base
            app.Address.RemoveAddress(1);
            //Insert Address in old collection
            oldList.Add(adress);
            //Sort old collection
            oldList.Sort();
            //Sort updated collection
            newList.Sort();
            //Compare collections
            Assert.AreEqual(oldList,newList);
        }
    }
}
