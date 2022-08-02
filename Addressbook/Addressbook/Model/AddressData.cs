using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressData: IComparable
    {
        private string allPhones;
        private string allEmails;
        private string all;

        public AddressData() { }
        public AddressData(string fname)
        {
            Fname = fname;
        }
        public AddressData(string fname, string lname)
        {
            Fname = fname;
            Lname = lname;
        }
        public string Fname {get;set;}
        public string Lname { get;set;}
        public string Mname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                    return allPhones;
                return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
            }
            set { allPhones = value; }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                    return allEmails;
                return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
            }
            set { allEmails = value; }
        }

        public string All
        {
            get
            {
                if (all != null)
                    return all;
                return (CleanUpAttribute(CleanUpNames(Fname) + CleanUpNames(Mname) +
                    CleanUpNames(Lname)) +
                    CleanUpAttribute(Address) +
                    SetBreaks(CleanUp(HomePhone,1) + CleanUp(MobilePhone,2) + CleanUp(WorkPhone,3)) +
                    SetBreaks(CleanUpAttribute(Email) + CleanUpAttribute(Email2) + CleanUpAttribute(Email3))).Trim();
            }
            set { all = value; }
        }


        private string CleanUp(string phone, int attribute = 0)
        {
            if (phone == null || phone == "")
                return "";
            string res = "";
            if (attribute == 1) res += "H: ";
            if (attribute == 2) res += "M: ";
            if (attribute == 3) res += "W: ";

            return res + Regex.Replace(phone, "[ -()]" ,"") + "\r\n";
            //phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")",
        }
        private string CleanUpNames(string name)
        {
            if (name == null || name == "")
                return "";

            return name + " ";
        }
        private string SetBreaks(string name)
        {
            if (name == null || name == "")
                return "";

            return "\r\n" + name;
        }
        private string CleanUpAttribute(string name)
        {
            if (name == null || name == "")
                return "";

            return (name).Trim() + "\r\n";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            AddressData a = obj as AddressData;
            if (a as AddressData == null)
                return false;
            return Fname == a.Fname && Lname == a.Lname;
        }

        public bool Equals(AddressData others)
        {
            if (others == null)
                return false;

            return Fname == others.Fname && Lname == others.Lname;
        }

        public int CompareTo(AddressData others)
        {
            if (others == null)
                return 1;
            int cmp = Lname.CompareTo(others.Lname);
            if (cmp != 0)
                return cmp;

            return Fname.CompareTo(others.Fname);
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            AddressData a = obj as AddressData;
            if (a as AddressData != null)
                return CompareTo(a);
            return 1;
        }

        public override string ToString()
        {
            return "Fname = " + Fname + "\nLname = " + Lname;
        }

        public override int GetHashCode()
        {
            return Fname.GetHashCode() + Lname.GetHashCode();
        }
    }
}
