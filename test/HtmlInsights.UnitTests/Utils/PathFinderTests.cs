using AutoFixture.Xunit2;
using FluentAssertions;
using HtmlAgilityPack;
using HtmlInsights.UnitTests.Fixture;
using System.Linq;
using Xunit;

namespace HtmlInsights.Utils.UnitTests
{
    public class PathFinderTests
    {
        [Theory, AutoData]
        public void GetPath_WithNoDescendants_ShouldHave0Depth(
            HtmlDocument document,
            string criteria
        )
        {
            // Arrange
            IPathFinder sut = new PathFinder();
            document.LoadHtml("");
            var firstTag = document.DocumentNode.Descendants().FirstOrDefault();

            // Act
            var actual = sut.GetPath(firstTag, criteria);

            // Assert
            actual.Depth.Should().Be(0);
        }

        [Theory]
        [InlineAutoData(10)]
        [InlineAutoData(20)]
        [InlineAutoData(30)]
        [InlineAutoData(50)]
        public void GetPath_Depth_WithSimpleDescendants_ShouldMatch(

            int expectedDepth,
            HtmlDocument document,
            string criteria
        )
        {
            // Arrange
            IPathFinder sut = new PathFinder();
            document.LoadHtml(GenerateDivs(expectedDepth));
            var firstTag = document.DocumentNode.Descendants().FirstOrDefault();

            // Act
            var actual = sut.GetPath(firstTag, criteria);

            // Assert
            actual.Depth.Should().Be(expectedDepth);
        }


        [Theory, InlineAutoData(10)]
        public void GetPath_Matches_WithRandomCriteria_ShouldBeZeroMatch(

            int expectedDepth,
            HtmlDocument document,
            string criteria
        )
        {
            // Arrange
            var expectedMatches = 0;
            IPathFinder sut = new PathFinder();
            document.LoadHtml(GenerateDivs(expectedDepth));
            var firstTag = document.DocumentNode.Descendants().FirstOrDefault();

            // Act
            var actual = sut.GetPath(firstTag, criteria);

            // Assert
            actual.Matches.Should().Be(expectedMatches);
        }


        [Theory, InlineAutoData(10)]
        public void GetPath_Matches_WithSameCriteria_ShouldBeMatchDepth(

            int expectedDepth,
            HtmlDocument document
        )
        {
            // Arrange
            IPathFinder sut = new PathFinder();
            document.LoadHtml(GenerateDivs(expectedDepth));
            var firstTag = document.DocumentNode.Descendants().FirstOrDefault();

            // Act
            var actual = sut.GetPath(firstTag, "div");

            // Assert
            actual.Matches.Should().Be(expectedDepth);
        }


        [Theory, AutoData]
        public void DoesNameMatch_WithRandomeTag_ShouldReturnFalse(
            HtmlDocument document,
            HtmlFixture fixture,
            string criteria
        )
        {
            // Arrange
            IPathFinder sut = new PathFinder();
            document.LoadHtml(fixture.EmptyHtmlFile);
            var firstTag = document.DocumentNode.Descendants().First();

            // Act
            var actual = sut.DoesNameMatch(firstTag, criteria);

            // Assert
            actual.Should().BeFalse();
        }

        [Theory, AutoData]
        public void DoesNameMatch_WithASingleTag_ShouldReturnTrue(
            HtmlDocument document
        )
        {
            // Arrange
            IPathFinder sut = new PathFinder();
            var criteria = "html";
            var expected = $"<{criteria}></{criteria}>";
            document.LoadHtml(expected);
            var firstTag = document.DocumentNode.Descendants().First();

            // Act
            var actual = sut.DoesNameMatch(firstTag, criteria);

            // Assert
            actual.Should().BeTrue();
        }

        public string GenerateDivs(int maxDepth)
        {
            var content = "";
            for (int i = 0; i < maxDepth; i++)
            {
                content += "<div>";
            }

            for (int i = 0; i < maxDepth; i++)
            {
                content += "</div>";
            }

            return content;
        }
    }
}
