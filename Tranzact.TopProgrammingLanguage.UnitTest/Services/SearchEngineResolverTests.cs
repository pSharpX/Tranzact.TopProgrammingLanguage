using FluentAssertions;
using NSubstitute;
using System;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories;
using Tranzact.TopProgrammingLanguage.Contracts.Services;
using Tranzact.TopProgrammingLanguage.Core.Services;
using Tranzact.TopProgrammingLanguage.Domain.Enums;
using Xunit;

namespace Tranzact.TopProgrammingLanguage.UnitTest.Services
{
    public class SearchEngineResolverTests
    {
        private readonly IGoogleSearchRepository _googleSearchRepository = Substitute.For<IGoogleSearchRepository>();
        private readonly IBingSearchRepository _bingSearchRepository = Substitute.For<IBingSearchRepository>();
        private readonly IYahooSearchRepository _yahooSearchRepository = Substitute.For<IYahooSearchRepository>();

        private readonly GoogleSearchService _googleSearchService;
        private readonly BingSearchService _bingSearchService;
        private readonly YahooSearchService _yahooSearchService;

        private readonly ISearchEngineResolver _searchEngineResolver;

        public SearchEngineResolverTests()
        {
            _googleSearchService = Substitute.For<GoogleSearchService>(_googleSearchRepository);
            _bingSearchService = Substitute.For<BingSearchService>(_bingSearchRepository);
            _yahooSearchService = Substitute.For<YahooSearchService>(_yahooSearchRepository);
            _searchEngineResolver = new SearchEngineResolver(_googleSearchService, _bingSearchService, _yahooSearchService);
        }

        [Fact]
        public void Get_WithRegisteredType_ShouldReturnSearchEngineService()
        {
            // ARRANGE

            // ACT
            var searchEngineService = _searchEngineResolver.Get(SearchEngineTypes.GOOGLE);

            // ASSERT
            searchEngineService.Should().NotBeNull();
            searchEngineService.Should().Be(_googleSearchService);
        }

        [Fact]
        public void Get_WithUnRegisteredType_ShouldThrowNotImplementedException()
        {
            // ARRANGE

            // ACT
            Action action = () => _searchEngineResolver.Get(SearchEngineTypes.BAIDU);

            // ASSERT
            action.Should().Throw<NotImplementedException>()
                .WithMessage("search engine service not implemented");
        }
    }
}
