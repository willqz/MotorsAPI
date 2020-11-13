using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace Motors.Tests.Fixtures
{
    public class TestContext
    {
        public HttpClient Http { get; set; }

        private TestServer _server;

        public TestContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Http = _server.CreateClient();
        }
    }
}
