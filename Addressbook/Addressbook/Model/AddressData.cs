using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    internal class AddressData
    {
        private string fname = "";
        private string lname = "";
        


        public AddressData(string fname)
        {
            this.fname = fname;
        }

        public string Fname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }

        }
        public string Lname
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }
        
    }
}
