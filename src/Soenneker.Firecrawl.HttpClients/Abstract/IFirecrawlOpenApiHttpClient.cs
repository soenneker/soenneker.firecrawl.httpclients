using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Firecrawl.HttpClients.Abstract;

/// <summary>
/// Provides the cached, authenticated HTTP client used to call Firecrawl.
/// </summary>
public interface IFirecrawlOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the cached HTTP client configured for Firecrawl.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the shared HTTP client. The caller must not dispose it.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
