using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HtmlInsights.Utils
{
    public class HtmlParser
    {
        public HtmlWeb HtmlWeb { get; }

        public HtmlParser(HtmlWeb htmlWeb)
        {
            HtmlWeb = htmlWeb;
        }

        public async Task<IEnumerable<HtmlNode>> GetNodes(Uri uri) => 
            (await HtmlWeb.LoadFromWebAsync($"{uri}"))
                .DocumentNode
                .Descendants()
                .OnlyElements();
    }
}
