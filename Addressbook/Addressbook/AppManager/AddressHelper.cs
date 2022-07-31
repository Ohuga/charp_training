using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class AddressHelper : HelperBase
    {
        public AddressHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public AddressHelper AddIfEmptyList()
        {
            if (GetSearchCount() == 0)
            {
                FillNewAdd(new AddressData { Fname = "1", Lname = "2" });
            }
            return this;
        }
        private int GetSearchCount()
        {
            return int.Parse(driver.FindElement(By.Id("search_count")).Text);
        }

        public AddressHelper SubmitNewAdd()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public AddressHelper FillNewAdd(AddressData address)
        {
            Type(By.Name("firstname"), address.Fname);
            Type(By.Name("lastname"), address.Lname);
            return this;
        }
        public AddressHelper ReturnToAddressPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public AddressHelper RemoveAddress(int p)
        {
            GoToAddressPage();
            SelectAddress(p);
            DeleteAddress();
            CloseWindow();
            return this;
        }

        public AddressHelper CloseWindow()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
        }

        public AddressHelper DeleteAddress()
        {
            addressCache = null;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public AddressHelper SelectAddress(int p)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/table/tbody/tr["+(p+1)+"]/td[1]/input")).Click();
            return this;
        }

        public AddressHelper GoToAddressPage()
        {
            //driver.Navigate().GoToUrl("http://localhost/addressbook");
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public AddressHelper SubmitAddressModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public AddressHelper InitAddressModification(int p)
        {
            //driver.FindElement(By.Name("edit")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/table/tbody/tr[" + (p + 1) + "]/td[8]/a")).Click();
            return this;
        }

        public AddressHelper AddAddress(AddressData address)
        {
            addressCache = null;

            driver.FindElement(By.LinkText("add new")).Click();

            this
                .FillNewAdd(address)
                .SubmitNewAdd()
                .ReturnToAddressPage();
            return this;
        }

        public List<AddressData> GetAddressList()
        {
            if (addressCache == null)
            {
                addressCache = new List<AddressData>();
                manager.Navigator.GoToAddressPage();
                ICollection<IWebElement> elements = manager.Navigator.GetCollection("entry");
                foreach (IWebElement element in elements)
                {
                    ReadOnlyCollection<IWebElement> names = element.FindElements(By.TagName("td"));
                    String lname = names[1].Text;
                    String fname = names[2].Text;
                    addressCache.Add(new AddressData(fname, lname));
                }
            }
            return addressCache;
        }

        private List<AddressData> addressCache = null;

        public AddressData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string email = cells[4].Text;
            string allPhones = cells[5].Text;

            return new AddressData(firstName, lastName)
            {
                Address = address,
                Email = email,
                AllPhones = allPhones,
            };
        }

        public AddressData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            manager.Navigator.GoToAddressPage();
            InitAddressModification(index  + 1); 
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");

            return new AddressData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,  
                WorkPhone = workPhone,
                Email = email,
                Mname = middleName
            };
        }
        public String GetContactInformationFromProperty(int index)
        {
            manager.Navigator.GoToHomePage();
            GotoAddressInfo(index + 1);
            //return (Fname + " " + Lname + (Address) + Email + CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
            string all = driver.FindElement(By.Id("content")).FindElement(By.TagName("b")).Text;
            string content = driver.FindElement(By.Id("content")).Text;
            IList<string> attributes = content.Split('\n');
            //< a href = "mailto:email" > email </ a >
            all += attributes[4] +
                attributes[10] +
                Regex.Replace(attributes[6], @"H: ", String.Empty) + "\n" +
                Regex.Replace(attributes[7], @"M: ", String.Empty) + "\n" +
                Regex.Replace(attributes[8], @"W: ", String.Empty);
 
            return all;
        }

        private AddressHelper GotoAddressInfo(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/table/tbody/tr[" + (index + 1) + "]/td[7]/a")).Click();
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
    
}


