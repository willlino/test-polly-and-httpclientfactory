using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using teste_polly.domain.ApiService.Interface;

namespace teste_polly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubApiService gitHubApiService;

        public GitHubController(IGitHubApiService gitHubApiService)
        {
            this.gitHubApiService = gitHubApiService;
        }

        [Route("{user}")]
        [HttpGet]
        public async Task<ActionResult> Get(string user)
        {
            
            string stringResult = await this.gitHubApiService.LoadAccount(user);
            return Ok(stringResult);
        }
    }
}