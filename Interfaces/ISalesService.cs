
using SalesAnalyzer.Models;

namespace SalesAnalyzer.Interfaces
{
    public interface ISalesService
    {
        decimal CalculateAverage(IEnumerable<SalesRec> records, int fromYear, int toYear);
        double CalculateStandardDeviation(IEnumerable<SalesRec> records, int fromYear, int toYear);
    }
}
