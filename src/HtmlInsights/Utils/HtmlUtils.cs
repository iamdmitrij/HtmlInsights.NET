using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace HtmlInsights.Utils
{
    public static class HtmlUtils
    {
        /// <summary>
        /// Filters not relevant Html tags by scoping collect to <see cref="HtmlNodeType.Element"/> tags only.
        /// </summary>
        public static IEnumerable<HtmlNode> OnlyElements(
            this IEnumerable<HtmlNode> node)
        {
            return node.Where(n => n.NodeType == HtmlNodeType.Element);
        }
    }
}
