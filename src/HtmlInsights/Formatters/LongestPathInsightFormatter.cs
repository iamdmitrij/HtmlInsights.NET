using Colorful;
using System.Drawing;

namespace HtmlInsights.Formatters
{
    public class LongestPathInsightFormatter : IFormatter<(string Path, int Depth, int Matches)>
    {
        public StyleSheet StyleSheet { get; }

        public LongestPathInsightFormatter(StyleSheet styleSheet)
        {
            StyleSheet = styleSheet;
        }

        public void Format((string Path, int Depth, int Matches) context)
        {
            Console.WriteLine($"The longest path is: {context.Path}");

            Console.WriteLineStyled($"with depth of {context.Depth} " +
                $"and {context.Matches} matches.", StyleSheet);
        }
    }
}
