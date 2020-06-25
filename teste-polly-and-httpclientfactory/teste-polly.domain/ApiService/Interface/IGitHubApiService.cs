using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_polly.domain.ApiService.Interface
{
    public interface IGitHubApiService
    {
        Task<string> LoadAccount(string accountName);
    }
}
