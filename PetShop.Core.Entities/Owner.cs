using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }


        public Owner(string firstName, string lastName, string address, string mail, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Mail = mail;
            PhoneNumber = phoneNumber;
        }
    }
}
