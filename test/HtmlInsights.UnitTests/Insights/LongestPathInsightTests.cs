using AutoFixture.Xunit2;
using FluentAssertions;
using HtmlAgilityPack;
using HtmlInsights.Insights;
using HtmlInsights.UnitTests.Fixture;
using HtmlInsights.Utils;
using Xunit;

namespace HtmlInsights.UnitTests.Insights
{
    public class LongestPathInsightTests
    {
        [Theory, AutoData]
        public void GetInsight_UsingPathyHtmlFile_ShouldMatchTags(
            HtmlDocument document,
            HtmlFixture htmlFixture
        )
        {
            // Arrange
            var sut = new LongestPathInsight(new PopularityInsight(), new PathFinder());
            var expected = "div -> div -> div -> div -> div -> div -> div -> div -> div -> h3";
            document.LoadHtml(htmlFixture.PathyHtml);
            var content = document.DocumentNode.Descendants().OnlyElements();

            // Act
            var actual = sut.GetInsight(content);

            // Assert
            actual.Path.Should().Be(expected);
        }
    }
}
