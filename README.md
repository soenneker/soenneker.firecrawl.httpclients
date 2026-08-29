[![](https://img.shields.io/nuget/v/soenneker.firecrawl.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.firecrawl.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.firecrawl.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.firecrawl.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.firecrawl.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.firecrawl.httpclients/)

# Soenneker.Firecrawl.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Firecrawl.HttpClients
```

## Quick start

```csharp
using Soenneker.Firecrawl.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddFirecrawlOpenApiHttpClientAsSingleton();
```

Adds `FirecrawlOpenApiHttpClient` as a singleton service.

## What you get

- `IFirecrawlOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `FirecrawlOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `FirecrawlOpenApiHttpClientRegistrar.AddFirecrawlOpenApiHttpClientAsSingleton(services)` | Adds `FirecrawlOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `FirecrawlOpenApiHttpClientRegistrar.AddFirecrawlOpenApiHttpClientAsScoped(services)` | Adds `FirecrawlOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
