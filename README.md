# Html Insights API 1.0

Html Insights is a console application API that provides insights to any HTML on the internet.

## Installation

To launch program you need to use [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) SDK, then simply execute following command:

```bash
dotnet run --project ./src/HtmlInsights/HtmlInsights.csproj
```

## Usage

Input URI of a page
```
Please input HTML URI:
https://revelsystems.com/lt/
```
Then you can run analysis on a given page.
```
1: Find all unique tags.
2: Find most popular tag
3: Find the longest path where the most popular tag is used the most times
C: Change URI
X: Exit
```