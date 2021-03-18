using System.Collections.Generic;
using Module3_Task2.Models.Entities;
using Module3_Task2.Models.Enums;

namespace Module3_Task2.Services.Contracts
{
    public interface IConfigService
    {
        public IList<IDictionary<Cultures, string>> LanguageConfig { get; }
    }
}
