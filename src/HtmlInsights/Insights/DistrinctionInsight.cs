using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace HtmlInsights.Insights
{
    public class DistrinctionInsight : BaseInsight<IEnumerable<string>>
    {
        public override IEnumerable<string> GetInsight(IEnumerable<HtmlNode> nodes) => nodes
            .Select(x => x.Name)
            .Distinct();
    }
}
