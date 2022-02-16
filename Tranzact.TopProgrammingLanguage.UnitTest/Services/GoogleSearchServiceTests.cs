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
    public class GoogleSearchServiceTests
    {
        private readonly IGoogleSearchRepository _searchRepository = Substitute.For<IGoogleSearchRepository>();
        private readonly ISearchService _searchService;

        public GoogleSearchServiceTests()
        {
            _searchService = new GoogleSearchService(_searchRepository);
        }

        [Fact]
        public async Task Search_WithSearchTermParameter_ShouldReturnSearchResultAsync()
        {
            // ARRANGE
            var fixture = new Fixture();
            var searchInformation = fixture.Build<SearchInformation>()
                .With(x => x.TotalResults, "250")
                .Create();
            var expectedSearhResult = fixture.Build<GoogleSearchResult>()
                .With(x => x.SearchInformation, searchInformation)
                .Create();
            var searchTerm = fixture.Create<string>();
            _searchRepository.Search(Arg.Any<String>()).Returns(expectedSearhResult);

            // ACT
            var searchResult = await _searchService.Search(searchTerm);

            // ASSERT
            searchResult.Should().NotBeNull();
            searchResult.Total.Should().Be(expectedSearhResult.GetTotal());
            searchResult.SearchEngineName.Should().Be(SearchEngineTypes.GOOGLE.ToString());
        }
    }
}
