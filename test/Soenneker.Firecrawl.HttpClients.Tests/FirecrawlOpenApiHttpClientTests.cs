using Soenneker.Firecrawl.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Firecrawl.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class FirecrawlOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IFirecrawlOpenApiHttpClient _httpclient;

    public FirecrawlOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IFirecrawlOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
