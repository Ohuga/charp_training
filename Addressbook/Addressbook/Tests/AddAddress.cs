using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddAddress : TestBase
    {
        

        [Test]
        public void AddAddressTest()
        {
            
            
            app.Navigator.GoToNewAdd();
            AddressData address = new AddressData("")
            {
                Fname = "Test1",
                Lname = "Test2"
            };
            app.Address
                .FillNewAdd(address)
                .SubmitNewAdd()
                .ReturnToAddressPage();
        }

       
    }
}
