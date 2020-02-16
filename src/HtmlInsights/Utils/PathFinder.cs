using HtmlAgilityPack;
using System;

namespace HtmlInsights.Utils
{
    public class PathFinder : IPathFinder
    {
        public (string Name, int Depth, int Matches) GetPath(HtmlNode node, string mostUsedTag)
        {
            if (node == null)
            {
                return (string.Empty, 0, 0);
            }

            var depth = 0;
            var matches = 0;
            var nodeName = node.Name;

            foreach (var child in node.ChildNodes.OnlyElements())
            {
                var (Name, Depth, Matches) = GetPath(child, mostUsedTag);
                depth = Math.Max(Depth, depth);
                matches = Math.Max(Matches, matches);
                nodeName = $"{nodeName} -> {Name}";
            }

            if (DoesNameMatch(node, mostUsedTag))
            {
                matches++;
            }

            return (nodeName, depth + 1, matches);
        }

        public bool DoesNameMatch(HtmlNode node, string mostUsedTag)
        {
            return node.Name == mostUsedTag;
        }
    }
}
