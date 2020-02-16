using Colorful;
using System.Drawing;

namespace HtmlInsights.Formatters
{
    public class PopularityInsightFormatter : IFormatter<(string Name, int Hits)>
    {
        public StyleSheet StyleSheet { get; }

        public PopularityInsightFormatter(StyleSheet styleSheet)
        {
            StyleSheet = styleSheet;
        }

        public void Format((string Name, int Hits) context)
        {
            Console.WriteLineStyled($"Most popular tag is {context.Name} " +
                $"with {context.Hits} matches.", StyleSheet);
        }
    }
}
