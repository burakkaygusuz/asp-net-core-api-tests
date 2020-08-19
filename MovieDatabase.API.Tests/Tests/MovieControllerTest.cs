using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MovieDatabase.API.Tests.Tests
{
    public class MovieControllerTest : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private readonly InMemoryWebApplicationFactory<Startup> factory;

        public MovieControllerTest(InMemoryWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }
        
        [Fact]
        public async Task GetAllMoviesRequest_HttpStatusCode_Returns_OK()
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync("/api/movies");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}