using System;
using System.Collections.Generic;

namespace Module3_Task2.Models.Entities
{
    public class Contact
    {
        public Contact(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string PhoneNumber { get; }

        public string FullName => $"{LastName} {FirstName}";
    }
}