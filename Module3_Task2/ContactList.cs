using System;
using System.Collections.Generic;
using Module3_Task2.Helpers;
using Module3_Task2.Models.Entities;
using Module3_Task2.Services;

namespace Module3_Task2
{
    public class ContactList
    {
        private const string DefaultCulture = "en-US";
        private const string NumbersKey = "0-9";

        private readonly string _alphabet;
        private IDictionary<string, List<Contact>> _list;

        public ContactList(string culture)
        {
            _list = new SortedDictionary<string, List<Contact>>();

            var config = new ConfigService();
            var languageConfig = config.LanguageConfig;
            string alphabet;

            foreach (var lang in languageConfig)
            {
                if (!lang.TryGetValue(culture, out alphabet))
                {
                    return;
                }

                _alphabet = alphabet;
            }
        }

        public ContactList()
            : this(DefaultCulture)
        {
        }

        public void Add(Contact contact)
        {
            string firstLetter = contact.FullName[0].ToString().ToLower();

            if (int.TryParse(firstLetter, out _))
            {
                AddToList(NumbersKey, contact);

                return;
            }

            for (int i = 0; i < _alphabet.Length; i++)
            {
                if (firstLetter == _alphabet[i].ToString().ToLower())
                {
                    AddToList(firstLetter, contact);

                    _list[firstLetter].Sort(new ContactAlphabeticalComparer());

                    return;
                }
            }

            AddToList("#", contact);
        }

        public void Remove(Contact contact)
        {
            foreach (KeyValuePair<string, List<Contact>> p in _list)
            {
                foreach (Contact item in p.Value)
                {
                    if (item.FullName == contact.FullName && item.PhoneNumber == contact.PhoneNumber)
                    {
                        p.Value.Remove(contact);
                    }
                }
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (KeyValuePair<string, List<Contact>> p in _list)
            {
                foreach (Contact contact in p.Value)
                {
                    yield return $"{p.Key}: {contact.FullName}";
                }
            }
        }

        private void AddToList(string key, Contact item)
        {
            if (_list.ContainsKey(key))
            {
                _list[key].Add(item);
                return;
            }
            else
            {
                _list.Add(key, new List<Contact> { item });
                return;
            }
        }
    }
}
