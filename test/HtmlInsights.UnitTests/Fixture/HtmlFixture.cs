using System.IO;

namespace HtmlInsights.UnitTests.Fixture
{
    public class HtmlFixture
    {
        private const string FilePattern = "Fixture/{0}.html";

        public string EmptyHtmlFile { get; } = File.ReadAllText(string.Format(FilePattern, nameof(EmptyHtmlFile)));

        public string PathyHtml { get; } = File.ReadAllText(string.Format(FilePattern, nameof(PathyHtml)));

        public string PopularHtml { get; } = File.ReadAllText(string.Format(FilePattern, nameof(PopularHtml)));
    }
}
