using Colorful;
using Figgle;
using HtmlAgilityPack;
using HtmlInsights.Formatters;
using HtmlInsights.Insights;
using HtmlInsights.Utils;
using System.Drawing;

namespace HtmlInsights
{
    public class Program
    {
        public static StyleSheet StyleSheet
        {
            get
            {
                var styleSheet = new StyleSheet(Color.Orange);
                styleSheet.AddStyle("[0-9]*", Color.MediumSlateBlue);

                return styleSheet;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Insights API 1.0"));

            // TODO: Not proud of this "UI" code, but it works. Need to refactor it. Interpretor pattern can work here.
            while (true)
            {
                System.Uri uri;
                while (true)
                {
                    Console.WriteLine("Please input HTML URI:");
                    var selectedUri = Console.ReadLine();

                    try
                    {
                        uri = new System.Uri(selectedUri);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("This is not a correct link try again.");
                        continue;
                    }
                }

                var downloader = new HtmlParser(new HtmlWeb());
                var content = downloader.GetNodes(uri).Result;

                while (true)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("1: Find all unique tags.", Color.Plum);
                    Console.WriteLine("2: Find most popular tag", Color.DarkKhaki);
                    Console.WriteLine("3: Find the longest path where the most popular tag is used the most times", Color.DarkGreen);
                    Console.WriteLine("C: Change URI", Color.DarkOrange);
                    Console.WriteLine("X: Exit", Color.Red);
                    Console.WriteLine("-----------------------");
                    var choice = Console.ReadLine();

                    if (choice.ToLowerInvariant() == "c")
                    {
                        break;
                    }
                    else if (choice.ToLowerInvariant() == "x")
                    {
                        Console.WriteLine(FiggleFonts.ThreePoint.Render("Good bye"));
                        return;
                    }
                    else if (choice == "1")
                    {
                        new DistrinctionInsightFormatter(new ColorAlternatorFactory())
                            .Format(new DistrinctionInsight()
                            .GetInsight(content));
                    }
                    else if (choice == "2")
                    {
                        new PopularityInsightFormatter(StyleSheet)
                            .Format(new PopularityInsight()
                            .GetInsight(content));
                    }
                    else if (choice == "3")
                    {
                        new LongestPathInsightFormatter(StyleSheet)
                            .Format(new LongestPathInsight(
                                new PopularityInsight(), 
                                new PathFinder())
                            .GetInsight(content));
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Select the one from the list.", Color.OrangeRed);
                    }
                }
            }
        }
    }
}
