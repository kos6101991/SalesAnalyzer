# SalesAnalyzer

A simple C# .NET console application that reads a sales data file and calculates statistical insights such as **average** and **standard deviation** 
over specific years or year ranges.

---

## Input File Format

The input file should contain **one sales record per line**, with the following format:

```
dd/MM/yyyy##amount
```

### Example:
```
31/03/2021##245.39
01/04/2021##199.99
...
```

The date and number format are configurable via `appsettings.json`.

---

## Configuration

In the root of the project, the `appsettings.json` file defines the date and number format:

```json
{
  "Format": {
    "Date": "dd/MM/yyyy",
    "Culture": "en-US"
  }
}
```

You can change the culture to `el-GR` or another valid .NET culture name.

---

## How to Use

1. Run the application.
2. Enter the full path to your sales file.
3. Choose a statistic to calculate:
   - `1`: Average earnings over a year range
   - `2`: Standard deviation for a specific year
   - `3`: Standard deviation over a year range
4. Enter the requested years.
5. Get your result.

---

## Tech Stack

- .NET 6 Console App
- Microsoft.Extensions.Hosting
- Dependency Injection
- Configuration via `appsettings.json`

---

## Sample Run

```
Enter the path to the sales file:
C:\Users\you\Desktop\sales.txt
Choose statistic:
1. Average for year range
2. Std Dev for specific year
3. Std Dev for year range
1
From year: 2020
To year: 2021
Average earnings (2020-2021): 182.44
```

---