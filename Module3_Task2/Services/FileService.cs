using System.IO;
using Module3_Task2.Services.Contracts;

namespace Module3_Task2.Services
{
    public class FileService : IFileService
    {
        public string ReadAllText(string path) => File.ReadAllText(path);
    }
}
