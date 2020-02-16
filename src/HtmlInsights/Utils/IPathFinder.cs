using HtmlAgilityPack;

namespace HtmlInsights.Utils
{
    public interface IPathFinder
    {
        /// <summary>
        /// Recursively finds a path in a node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="mostUsedTag"></param>
        /// <returns></returns>
        public (string Name, int Depth, int Matches) GetPath(HtmlNode node, string mostUsedTag);

        /// <summary>
        /// Determines whether <see cref="HtmlNode"/> name matches a name pattern.
        /// </summary>
        public bool DoesNameMatch(HtmlNode node, string mostUsedTag);
    }
}
