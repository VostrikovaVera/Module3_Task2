using System.Collections.Generic;

namespace Module3_Task2.Services.Contracts
{
    public interface IConfigService
    {
        public IList<IDictionary<string, string>> LanguageConfig { get; }
    }
}
