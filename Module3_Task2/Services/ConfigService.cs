using System.IO;
using System.Collections.Generic;
using Module3_Task2.Models.Entities;
using Module3_Task2.Services.Contracts;
using Newtonsoft.Json;
using Module3_Task2.Models.Enums;

namespace Module3_Task2.Services
{
    public class ConfigService : IConfigService
    {
        private readonly string _path = "config.json";
        private readonly IList<IDictionary<Cultures, string>> _languageConfig;
        private readonly IFileService _fileService;

        public ConfigService()
        {
            _fileService = new FileService();

            var config = GetConfig();
            _languageConfig = config.Languages;
        }

        public IList<IDictionary<Cultures, string>> LanguageConfig => _languageConfig;

        private Config GetConfig()
        {
            var config = _fileService.ReadAllText(_path);
            return JsonConvert.DeserializeObject<Config>(config);
        }
    }
}
