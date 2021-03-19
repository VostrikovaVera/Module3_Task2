using System.Collections.Generic;
using Module3_Task2.Models.Entities;

namespace Module3_Task2.Helpers
{
    public class ContactAlphabeticalComparer : IComparer<Contact>
    {
        public int Compare(Contact x, Contact y)
        {
            if (x.FullName == null || y.FullName == null)
            {
                return 0;
            }

            return x.FullName.CompareTo(y.FullName);
        }
    }
}
