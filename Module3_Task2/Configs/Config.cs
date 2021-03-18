using System.Collections.Generic;
using Module3_Task2.Models.Enums;

namespace Module3_Task2.Models.Entities
{
    public class Config
    {
        public IList<IDictionary<Cultures, string>> Languages { get; set; }
    }
}
