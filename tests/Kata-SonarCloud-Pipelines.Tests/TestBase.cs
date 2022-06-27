using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace HelloWorld.Tests;

public class TestBase
{
    protected readonly TestServer Server;

    public TestBase()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseTestServer();
            });

        Server = application.Server;
    }
}
