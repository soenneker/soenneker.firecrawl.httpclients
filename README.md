[![](https://img.shields.io/nuget/v/soenneker.firecrawl.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.firecrawl.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.firecrawl.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.firecrawl.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.firecrawl.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.firecrawl.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.firecrawl.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.firecrawl.httpclients/actions/workflows/codeql.yml)

# Soenneker.Firecrawl.HttpClients

A cached, authenticated `HttpClient` for Firecrawl's v2 API.

## Installation

```bash
dotnet add package Soenneker.Firecrawl.HttpClients
```

## Registration

```csharp
using Soenneker.Firecrawl.HttpClients.Registrars;

services.AddFirecrawlOpenApiHttpClientAsSingleton();
```

Keep the HTTP client wrapper singleton when it is consumed by scoped Firecrawl utilities. This lets utility scopes be disposed without tearing down the transport reused by later scopes.

## Configuration

```json
{
  "Firecrawl": {
    "ApiKey": "your-firecrawl-key"
  }
}
```

`Firecrawl:ApiKey` is required. The default base address is `https://api.firecrawl.dev/v2`, and authentication defaults to `Authorization: Bearer <key>`.

Optional settings under `Firecrawl` are `ClientBaseUrl`, `AuthHeaderName`, and `AuthHeaderValueTemplate`; the template replaces `{token}` with the API key. A base-address override is useful for an application-controlled test server. Store the key in secret storage and redact authorization headers from logs.

## Usage

```csharp
public sealed class FirecrawlTransport(IFirecrawlOpenApiHttpClient client)
{
    public ValueTask<HttpClient> Get(CancellationToken cancellationToken) =>
        client.Get(cancellationToken);
}
```

`Get()` initializes and returns the cached client. Callers do not own that `HttpClient` and must not dispose it. DI disposes the wrapper and removes the cached transport at the wrapper's lifetime boundary.

This package configures transport and authentication only. It does not model Firecrawl requests, retry rate-limited calls, or enforce which URLs may be submitted for crawling.
