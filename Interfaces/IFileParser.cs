using Microsoft.Extensions.Configuration;
using SalesAnalyzer.Models;

namespace SalesAnalyzer.Interfaces
{
    public interface IFileParser
    {
        List<SalesRec> ParseFile(string path, IConfiguration config);
    }
}
