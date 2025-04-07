
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesAnalyzer.Helpers;
using SalesAnalyzer.Interfaces;
using SalesAnalyzer.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IFileParser, FileParser>();
        services.AddSingleton<ISalesService, SalesService>();
    })
    .Build();

var config = host.Services.GetRequiredService<IConfiguration>();
var parser = host.Services.GetRequiredService<IFileParser>();
var processor = host.Services.GetRequiredService<ISalesService>();

Console.WriteLine("Enter the path to the sales file:");
var path = Console.ReadLine();
if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
{
    Console.WriteLine("Error: Invalid or missing file path.");
    return;
}
var records = parser.ParseFile(path!, config);

Console.WriteLine("Choose statistic: \n1. Average for year range\n2. Standard deviation for specific year\n3. Standard deviation for year range");
var choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.Write("From year: ");
        int from1 = int.Parse(Console.ReadLine()!);
        Console.Write("To year: ");
        int to1 = int.Parse(Console.ReadLine()!);
        var avg = processor.CalculateAverage(records, from1, to1);
        Console.WriteLine($"Average earnings ({from1}-{to1}): {avg:F2}");
        break;
    case "2":
        Console.Write("Year: ");
        int year2 = int.Parse(Console.ReadLine()!);
        var std2 = processor.CalculateStandardDeviation(records, year2, year2);
        Console.WriteLine($"Standard deviation for {year2}: {std2:F2}");
        break;
    case "3":
        Console.Write("From year: ");
        int from3 = int.Parse(Console.ReadLine()!);
        Console.Write("To year: ");
        int to3 = int.Parse(Console.ReadLine()!);
        var std3 = processor.CalculateStandardDeviation(records, from3, to3);
        Console.WriteLine($"Standard deviation ({from3}-{to3}): {std3:F2}");
        break;
    default:
        Console.WriteLine("Invalid choice");
        break;
}
Console.ReadLine();