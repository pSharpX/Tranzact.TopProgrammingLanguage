using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.Protected;
using NSubstitute;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Config;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories;
using Tranzact.TopProgrammingLanguage.Contracts.Providers;
using Tranzact.TopProgrammingLanguage.Infrastructure.Data.Repositories;
using Tranzact.TopProgrammingLanguage.UnitTest.Helpers;
using Xunit;

namespace Tranzact.TopProgrammingLanguage.UnitTest.Repositories
{
    public class BingSearchRepositoryTests
    {
        private const string FAKE_BASE_URL = "http://localhost:8080/bing-api";

        private readonly Fixture fixture = new();

        private readonly IHttpClientProvider clientProvider = Substitute.For<IHttpClientProvider>();
        private readonly IBingConfigProvider configProvider = Substitute.For<IBingConfigProvider>();

        private IBingSearchRepository _searchRepository;

        [Fact]
        public async Task Search_WithSearchTermParameter_ShouldReturnSearchResultsAsync()
        {
            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(BingResponseTestData()),
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            var searchTerm = fixture.Create<string>();
            var engineConfig = fixture.Build<BingEngineConfig>()
                .With(x => x.BaseUrl, FAKE_BASE_URL)
                .Create();

            clientProvider.GetHttpClient().Returns(httpClient);
            configProvider.GetSearchEngineConfig().Returns(engineConfig);

            _searchRepository = new BingSearchRepository(clientProvider, configProvider);

            // ACT
            var result = await _searchRepository.Search(searchTerm);

            // ASSERT
            result.Should().NotBeNull();
            result.GetTotal().Should().Be(46400000);
        }

        [Fact]
        public async Task Search_WithNotSuccessStatusCode_ShouldReturnDefaultSearchResults()
        {
            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.Forbidden
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            var searchTerm = fixture.Create<string>();
            var engineConfig = fixture.Build<BingEngineConfig>()
                .With(x => x.BaseUrl, FAKE_BASE_URL)
                .Create();

            clientProvider.GetHttpClient().Returns(httpClient);
            configProvider.GetSearchEngineConfig().Returns(engineConfig);

            _searchRepository = new BingSearchRepository(clientProvider, configProvider);

            // ACT
            var result = await _searchRepository.Search(searchTerm);

            // ASSERT
            result.Should().NotBeNull();
            result.GetTotal().Should().Be(0);
        }

        public static string BingResponseTestData()
        {
            return TestHelper.GetContent(TestHelper.SUCCESSFUL_BING_RESPONSE);
        }
    }
}
