using Colorful;
using System.Collections.Generic;
using System.Drawing;

namespace HtmlInsights.Formatters
{
    public class DistrinctionInsightFormatter : IFormatter<IEnumerable<string>>
    {
        public ColorAlternatorFactory ColorAlternatorFactory { get; }

        public DistrinctionInsightFormatter(ColorAlternatorFactory colorAlternatorFactory)
        {
            ColorAlternatorFactory = colorAlternatorFactory;
        }

        public void Format(IEnumerable<string> context)
        {
            foreach (var line in context)
            {
                var alternator = ColorAlternatorFactory.GetAlternator(5, Color.Plum, Color.PaleVioletRed);
                Console.WriteLineAlternating(line, alternator);
            }

            Console.WriteLine(string.Empty);
        }
    }
}
