using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Firecrawl.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Firecrawl.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class FirecrawlOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="FirecrawlOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddFirecrawlOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IFirecrawlOpenApiHttpClient, FirecrawlOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="FirecrawlOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddFirecrawlOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IFirecrawlOpenApiHttpClient, FirecrawlOpenApiHttpClient>();

        return services;
    }
}
