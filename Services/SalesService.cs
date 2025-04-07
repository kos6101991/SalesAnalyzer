using SalesAnalyzer.Interfaces;
using SalesAnalyzer.Models;

namespace SalesAnalyzer.Services
{
    public class SalesService : ISalesService
    {
        public decimal CalculateAverage(IEnumerable<SalesRec> records, int fromYear, int toYear)
        {
            var filtered = records.Where(r => r.Day.Year >= fromYear && r.Day.Year <= toYear).Select(r => r.Amount);
            return filtered.Any() ? filtered.Average() : 0;
        }

        public double CalculateStandardDeviation(IEnumerable<SalesRec> records, int fromYear, int toYear)
        {
            var filtered = records.Where(r => r.Day.Year >= fromYear && r.Day.Year <= toYear).Select(r => (double)r.Amount).ToList();
            if (!filtered.Any()) return 0;
            var avg = filtered.Average();
            var sumSq = filtered.Sum(a => Math.Pow(a - avg, 2));
            return Math.Sqrt(sumSq / filtered.Count);
        }
    }
}
