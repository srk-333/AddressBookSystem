using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class ContactModel
    {
        //Contact Entity
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long Zip { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string B_ID { get; set; }
        public string B_Name { get; set; }
        public string B_Type { get; set; }
    }
}