using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories;
using Tranzact.TopProgrammingLanguage.Contracts.Dto;
using Tranzact.TopProgrammingLanguage.Contracts.Services;
using Tranzact.TopProgrammingLanguage.Core.Services;
using Tranzact.TopProgrammingLanguage.Domain.Entities;
using Tranzact.TopProgrammingLanguage.Domain.Enums;
using Xunit;

namespace Tranzact.TopProgrammingLanguage.UnitTest.Services
{
    public class SearchFightServiceTests
    {
        private readonly Fixture fixture = new();

        private readonly IGoogleSearchRepository _googleSearchRepository = Substitute.For<IGoogleSearchRepository>();
        private readonly IBingSearchRepository _bingSearchRepository = Substitute.For<IBingSearchRepository>();
        private readonly IYahooSearchRepository _yahooSearchRepository = Substitute.For<IYahooSearchRepository>();

        private readonly GoogleSearchService _googleSearchService;
        private readonly BingSearchService _bingSearchService;
        private readonly YahooSearchService _yahooSearchService;

        private readonly ISearchFightService _searchService;

        public SearchFightServiceTests()
        {
            _googleSearchService = Substitute.ForPartsOf<GoogleSearchService>(_googleSearchRepository);
            _bingSearchService = Substitute.ForPartsOf<BingSearchService>(_bingSearchRepository);
            _yahooSearchService = Substitute.ForPartsOf<YahooSearchService>(_yahooSearchRepository);

            ISearchEngineResolver searchEngineResolver = new SearchEngineResolver(_googleSearchService, _bingSearchService, _yahooSearchService);
            _searchService = new SearchFightService(searchEngineResolver);
        }

        [Theory]
        [InlineAutoData("java", 4500000, 1500000)]
        [InlineAutoData("php", 14000000, 18000000)]
        public async Task Process_WithSearchRequest_ShouldReturnSearchResponseAsync(string searchTerm, int googleTotalResults, int bingTotalResults)
        {
            // ARRANGE
            var request = fixture.Build<SearchRequest>()
                .With(x => x.SearchTerms, new List<string>() { searchTerm })
                .Create();

            var expectedGoogleResults = MockGoogleSearchResult(searchTerm, googleTotalResults);
            var expectedBingResults = MockBingSearchResult(searchTerm, bingTotalResults);

            _googleSearchRepository.Search(Arg.Any<string>()).Returns(expectedGoogleResults);
            _bingSearchRepository.Search(Arg.Any<string>()).Returns(expectedBingResults);

            // ACT
            var searchResponse = await _searchService.Process(request);

            searchResponse.Should().NotBeNull();
            searchResponse.ResultsBySearchEngine.Should().NotBeEmpty()
                .And.HaveCount(2)
                .And.ContainSingle(x => x.SearchEngine.Equals(SearchEngineTypes.GOOGLE.ToString()))
                .And.ContainSingle(x => x.SearchEngine.Equals(SearchEngineTypes.BING.ToString())); ;

            searchResponse.ResultsBySearchTerm.Should().NotBeEmpty()
                .And.ContainSingle()
                .And.OnlyContain(x => searchTerm.Equals(x.SearchTerm));
        }

        private GoogleSearchResult MockGoogleSearchResult(string searchTerm, int totalResult)
        {
            var searchInformation = fixture.Build<SearchInformation>()
                .With(x => x.TotalResults, totalResult.ToString())
                .Create();
            var searchQueries = fixture.Build<SearchQueries>()
                .With(x => x.Request, new List<SearchQuery> { new SearchQuery { SearchTerms = searchTerm } })
                .Create();
            var mockResults = fixture.Build<GoogleSearchResult>()
                .With(x => x.SearchInformation, searchInformation)
                .With(x => x.Queries, searchQueries)
                .Create();
            return mockResults;
        }

        private BingSearchResult MockBingSearchResult(string searchTerm, int totalResult)
        {
            var webPages = fixture.Build<WebPages>()
               .With(x => x.TotalEstimatedMatches, totalResult)
               .Create();
            var queryContext = fixture.Build<QueryContext>()
                .With(x => x.OriginalQuery, searchTerm)
                .Create();
            var mockResults = fixture.Build<BingSearchResult>()
                .With(x => x.WebPages, webPages)
                .With(x => x.QueryContext, queryContext)
                .Create();
            return mockResults;
        }
    }
}
