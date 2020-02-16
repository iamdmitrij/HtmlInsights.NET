using AutoFixture.Xunit2;
using FluentAssertions;
using HtmlAgilityPack;
using HtmlInsights.Insights;
using HtmlInsights.UnitTests.Fixture;
using HtmlInsights.Utils;
using Xunit;

namespace HtmlInsights.UnitTests.Insights
{
    public class DistrinctionInsightTests
    {
        [Theory, AutoData]
        public void GetInsight_UsingEmptyHtmlFile_ShouldMatchTags(
            HtmlDocument document,
            HtmlFixture htmlFixture
        )
        {
            // Arrange
            var sut = new DistrinctionInsight();
            var expected = new string[] { "html", "head", "meta", "title", "body" };
            document.LoadHtml(htmlFixture.EmptyHtmlFile);
            var content = document.DocumentNode.Descendants().OnlyElements();

            // Act
            var actual = sut.GetInsight(content);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
