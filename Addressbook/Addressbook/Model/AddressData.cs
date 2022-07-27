using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressData: IComparable
    {
                
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
