using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using teste_polly.domain.ApiService.Interface;

namespace teste_polly.domain.ApiService
{
    public class GitHubApiService : IGitHubApiService
    {
        private readonly HttpClient httpClient;


        public GitHubApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> LoadAccount(string accountName)
        {
            string accountInfo = await httpClient.GetStringAsync($"users/{accountName}");
            return accountInfo;
        }
    }
}
