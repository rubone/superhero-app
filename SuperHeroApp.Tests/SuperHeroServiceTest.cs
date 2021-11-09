using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using SuperHeroApp.Services;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SuperHeroApp.Tests
{
    public class SuperHeroServiceTest
    {
        private readonly Mock<IConfiguration> _mock;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly SuperHeroService _service;

        public SuperHeroServiceTest()
        {
            _mock = new Mock<IConfiguration>();
            var _section = new Mock<IConfigurationSection>();
            var _sectionBaseURL = new Mock<IConfigurationSection>();
            var _sectionToken = new Mock<IConfigurationSection>();
            var _sectionEndpoints = new Mock<IConfigurationSection>();
            var _sectionSearch = new Mock<IConfigurationSection>();

            _sectionBaseURL.Setup(m => m.Value).Returns("http://localhost");
            _sectionToken.Setup(m => m.Value).Returns("787455");
            _sectionSearch.Setup(m => m.Value).Returns("Search");
            _sectionEndpoints.Setup(m => m.GetSection("Search")).Returns(_sectionSearch.Object);
            _section.Setup(m => m.GetSection("BaseURL")).Returns(_sectionBaseURL.Object);
            _section.Setup(m => m.GetSection("Token")).Returns(_sectionToken.Object);
            _section.Setup(m => m.GetSection("Endpoints")).Returns(_sectionEndpoints.Object);

            _mock.Setup(m => m.GetSection("SuperHeroAPI")).Returns(_section.Object);
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _service = new SuperHeroService(_mock.Object);
        }
        

        [Fact]
        public async Task FilterShouldBeEqualToSearchResultResultsFor()
        {
            //Arrange            
            _mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                new HttpResponseMessage() { 
                    StatusCode = System.Net.HttpStatusCode.OK, 
                    Content = new StringContent(
                        "{ \"response\": \"succes\", \"results-for\": \"batman\", \"results\":  [ { \"id\" : \"69\", \"name\" : \"batman\"} ] }", 
                        Encoding.UTF8, 
                        "application/json") 
                });

            //Act
            var searchResult = await _service.SearchSuperHero("batman", _mockHttpMessageHandler.Object);

            //Assert
            Assert.Equal("batman", searchResult.ResultsFor);
        }
    }
}
