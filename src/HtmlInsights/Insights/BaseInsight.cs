using HtmlAgilityPack;
using System.Collections.Generic;

namespace HtmlInsights.Insights
{
    public abstract class BaseInsight<T>
    {
        /// <summary>
        /// Get insights of a aggregate of <see cref="T"/>.
        /// </summary>
        /// <param name="nodes">HTML nodes to search in</param>
        public abstract T GetInsight(IEnumerable<HtmlNode> nodes);
    }
}
