using HtmlAgilityPack;
using HtmlInsights.Utils;
using System.Collections.Generic;
using System.Linq;

namespace HtmlInsights.Insights
{
    public class LongestPathInsight : BaseInsight<(string Path, int Depth, int Matches)>
    {
        public PopularityInsight PopularityInsight { get; }

        public IPathFinder PathFinder { get; }

        public LongestPathInsight(PopularityInsight popularityInsight, IPathFinder pathFinder)
        {
            PopularityInsight = popularityInsight;
            PathFinder = pathFinder;
        }

        public override (string Path, int Depth, int Matches) GetInsight(IEnumerable<HtmlNode> nodes)
        {
            var mostUsedTag = PopularityInsight.GetInsight(nodes).Name;

            var paths = nodes
                .OfType<HtmlNode>()
                .Select(x => PathFinder.GetPath(x, mostUsedTag))
                .Where(x => x.Matches > 0);

            return paths
                .OrderByDescending(x => x.Matches)
                .ThenByDescending(x => x.Depth)
                .FirstOrDefault();
        }
    }
}
