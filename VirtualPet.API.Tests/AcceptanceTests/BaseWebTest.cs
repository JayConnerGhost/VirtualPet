using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace VirtualPet.API.Tests.AcceptanceTests
{
    public class BaseWebTest
    {
        internal readonly TestServer _server;
        internal readonly HttpClient _client;

        public BaseWebTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Web.Startup>());
            _client = _server.CreateClient();
        }
    }
}