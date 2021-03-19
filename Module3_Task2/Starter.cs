using System;
using System.Collections.Generic;
using System.Globalization;
using Module3_Task2.Models.Entities;

namespace Module3_Task2
{
    public class Starter
    {
        public void Run()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            var contactList = new ContactList(culture.Name);

            contactList.Add(new Contact("Rachel", "Green", "33333333333"));
            contactList.Add(new Contact("Joey", "Tribbiani", "123123123"));
            contactList.Add(new Contact("Ross", "Geller", "11111111111"));
            contactList.Add(new Contact("Monica", "Geller", "22222222222"));
            contactList.Add(new Contact("Phoebe", "Buffay", "4444444444444"));
            contactList.Add(new Contact("Chandler", "Bing", "55555555555"));
            contactList.Add(new Contact("apartment", "15", "777777777"));
            contactList.Add(new Contact("Pizza", "*", "123456789"));

            contactList.Remove(new Contact("Pizza", "*", "123456789"));

            foreach (string p in contactList)
            {
                Console.WriteLine(p);
            }
        }
    }
}
