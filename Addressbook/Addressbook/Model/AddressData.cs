using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressData
    {
                
        public AddressData() { }
        public AddressData(string fname)
        {
            Fname = fname;
        }
        public string Fname {get;set;}
        
        public string Lname { get;set;}
        
    }
}
