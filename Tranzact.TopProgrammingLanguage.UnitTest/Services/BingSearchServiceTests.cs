using AutoFixture;
using FluentAssertions;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Entities;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories;
using Tranzact.TopProgrammingLanguage.Contracts.Enum;
using Tranzact.TopProgrammingLanguage.Contracts.Services;
using Tranzact.TopProgrammingLanguage.Core.Services;
using Xunit;

namespace Tranzact.TopProgrammingLanguage.UnitTest.Services
{
    public class BingSearchServiceTests
    {
        private readonly IBingSearchRepository _searchRepository = Substitute.For<IBingSearchRepository>();
        private readonly ISearchService _searchService;

        public BingSearchServiceTests()
        {
            _searchService = new BingSearchService(_searchRepository);
        }

        [Fact]
        public async Task Search_WithSearchTermParameter_ShouldReturnSearchResultAsync()
        {
            // ARRANGE
            var fixture = new Fixture();
            var webPages = fixture.Build<WebPages>()
                .With(x => x.TotalEstimatedMatches, 250)
                .Create();
            var expectedSearhResult = fixture.Build<BingSearchResult>()
                .With(x => x.WebPages, webPages)
                .Create();
            var searchTerm = fixture.Create<string>();
            _searchRepository.Search(Arg.Any<String>()).Returns(expectedSearhResult);

            // ACT
            var searchResult = await _searchService.Search(searchTerm);

            // ASSERT
            searchResult.Should().NotBeNull();
            searchResult.Total.Should().Be(expectedSearhResult.GetTotal());
            searchResult.SearchEngineName.Should().Be(SearchEngineTypes.BING.ToString());
        }
    }
}
