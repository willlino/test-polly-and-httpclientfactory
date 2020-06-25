using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using teste_polly.domain.ApiService;
using teste_polly.domain.ApiService.Interface;

namespace teste_polly.injection
{
    public static class DependencyRegister
    {
        public static void Register(IServiceCollection services)
        {
            RegisterHttpClients(services);
        }

        private static void RegisterHttpClients(IServiceCollection services)
        {
            services.AddHttpClient<IGitHubApiService, GitHubApiService>("GitHub", client =>
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryExample");
            })
              .AddTransientHttpErrorPolicy(x => x.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300)));
        }
    }
}
