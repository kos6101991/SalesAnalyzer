using Microsoft.Extensions.Configuration;
using SalesAnalyzer.Interfaces;
using SalesAnalyzer.Models;
using System.Globalization;

namespace SalesAnalyzer.Helpers
{
    public class FileParser : IFileParser
    {
        public List<SalesRec> ParseFile(string path, IConfiguration config)
        {
            var records = new List<SalesRec>();
            var dateFormat = config["Format:Date"] ?? "dd/MM/yyyy";
            var culture = CultureInfo.GetCultureInfo(config["Format:Culture"] ?? "en-US");

            foreach (var line in File.ReadLines(path))
            {
                var parts = line.Split("##");
                if (parts.Length != 2) continue;
                if (DateTime.TryParseExact(parts[0], dateFormat, culture, DateTimeStyles.None, out var date) &&
                    decimal.TryParse(parts[1], NumberStyles.Any, culture, out var amount))
                {
                    records.Add(new SalesRec { Day = date, Amount = amount });
                }
            }
            return records;
        }
    }
}
