using AutoFixture.Xunit2;
using FluentAssertions;
using HtmlAgilityPack;
using HtmlInsights.Insights;
using HtmlInsights.UnitTests.Fixture;
using HtmlInsights.Utils;
using Xunit;

namespace HtmlInsights.UnitTests.Insights
{
    public class PopularityInsightTests
    {
        [Theory, AutoData]
        public void GetInsight_UsingPopularHtmlFile_ShouldMatchTags(
            HtmlDocument document,
            HtmlFixture htmlFixture
        )
        {
            // Arrange
            var sut = new PopularityInsight();
            var expected = "li";
            document.LoadHtml(htmlFixture.PopularHtml);
            var content = document.DocumentNode.Descendants().OnlyElements();

            // Act
            var actual = sut.GetInsight(content);

            // Assert
            actual.Name.Should().Be(expected);
        }
    }
}
