using FluentAssertions;
using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace HtmlInsights.Utils.UnitTests
{
    public class HtmlDownloaderTests
    {
        public async Task TestGoogle_PlainUri_ShouldReturnHtml()
        {
            // Arrange
            var sut = new HtmlParser(new HtmlWeb());

            // Act
            var actual = await sut.GetNodes(new Uri("https://google.lt"));

            // Assert
            actual.Should().NotBeEmpty();
        }
    }
}
