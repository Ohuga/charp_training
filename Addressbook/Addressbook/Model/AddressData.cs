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
        public string Address { get; set; }
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

        public string All
        {
            get
            {// Todo rewrite
                if (allPhones != null)
                    return allPhones;
                return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
            }
            set { allPhones = value; }
        }


        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
                return "";

            return Regex.Replace(phone, "[ -()]" ,"") + "\r\n";
            //phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")",
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
    }
}
