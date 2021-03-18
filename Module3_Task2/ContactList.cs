using System;
using System.Collections.Generic;
using Module3_Task2.Helpers;
using Module3_Task2.Models.Entities;
using Module3_Task2.Models.Enums;
using Module3_Task2.Services;

namespace Module3_Task2
{
    public class ContactList
    {
        private const Cultures DefaultCulture = Cultures.Eng;
        private const string NumbersKey = "0-9";

        private readonly string _alphabet;
        private IDictionary<string, List<Contact>> _list;

        public ContactList(Cultures culture)
        {
            _list = new SortedDictionary<string, List<Contact>>();

            var config = new ConfigService();
            var languageConfig = config.LanguageConfig;

            foreach (var lang in languageConfig)
            {
                if (!lang.TryGetValue(culture, out _alphabet))
                {
                    return;
                }
            }
        }

        public ContactList()
            : this(DefaultCulture)
        {
        }

        public void Add(Contact contact)
        {
            string firstLetter = contact.FullName[0].ToString().ToLower();

            for (int i = 0; i < _alphabet.Length; i++)
            {
                if (firstLetter == _alphabet[i].ToString())
                {
                    AddToList(firstLetter, contact);
                    _list[firstLetter].Sort(new ContactAlphabeticalComparer());
                }
                else if (int.TryParse(firstLetter, out _))
                {
                    AddToList(NumbersKey, contact);
                }
                else
                {
                    AddToList("#", contact);
                }
            }
        }

        private void AddToList(string key, Contact item)
        {
            if (_list.ContainsKey(key))
            {
                _list[key].Add(item);
            }
            else
            {
                _list.Add(key, new List<Contact> { item });
            }
        }
    }
}
