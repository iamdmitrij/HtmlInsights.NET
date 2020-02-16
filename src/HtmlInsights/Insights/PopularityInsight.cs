using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace HtmlInsights.Insights
{
    public class PopularityInsight : BaseInsight<(string Name, int Hits)>
    {
        public override (string Name, int Hits) GetInsight(IEnumerable<HtmlNode> nodes) => nodes
            .GroupBy(x => x.Name)
            .Select(x => (x.Key, Hits: x.Count()))
            .OrderByDescending(x => x.Hits)
            .FirstOrDefault();
    }
}
