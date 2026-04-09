using Soenneker.Firecrawl.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Firecrawl.HttpClients.Tests;

[Collection("Collection")]
public sealed class FirecrawlOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IFirecrawlOpenApiHttpClient _httpclient;

    public FirecrawlOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IFirecrawlOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
