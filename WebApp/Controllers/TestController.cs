using System;
using System.Net.Http;
using System.Threading.Tasks;
using DAL.App.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.ViewModels.Test;

namespace WebApp.Controllers
{
    /// <summary>
    /// Test controller
    /// </summary>
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly AppDbContext _ctx;
        private readonly HttpClientAdapter _adpater;

        /// <summary>
        /// Test controller constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="ctx">App DB context</param>
        /// <param name="adpater">Http client adapter</param>
        public TestController(ILogger<TestController> logger, AppDbContext ctx, HttpClientAdapter adpater)
        {
            _logger = logger;
            _ctx = ctx;
            _adpater = adpater;
        }

        // GET
        /// <summary>
        /// Run test of getting characters.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Test()
        {
            _logger.LogInformation("Test method starts");
            var vm = new TestViewModel
            {
                Characters = await _ctx
                    .Characters
                    .Include(a => a.Pictures)
                    .Include(a => a.CharacterInLists)
                        .ThenInclude(a => a.FavCharacterList)
                    .Include(a => a.CharacterPersons)
                        .ThenInclude(a => a.WorkAuthor)
                            .ThenInclude(a => a!.WorkAuthorRoles)
                                .ThenInclude(a => a.Role)
                    .Include(a => a.CharacterPersons)
                        .ThenInclude(a => a.WorkAuthor)
                            .ThenInclude(a => a!.Person)
                                .ThenInclude(a => a!.PersonPictures)
                    .Include(a => a.WorkCharacters)
                        .ThenInclude(a => a.Work)
                            .ThenInclude(a => a!.CoverPictures)
                    .ToListAsync()
            };
            _logger.LogInformation("Test method pre-return");
            return View(vm);
        }

        /// <summary>
        /// Auth test
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public string TestAuth()
        {
            return "OK";
        }
    }

    /// <summary>
    /// HTTP client adapter
    /// </summary>
    public class HttpClientAdapter
    {
        /// <summary>
        /// Get length of the page
        /// </summary>
        /// <param name="url">Page URL</param>
        /// <returns></returns>
        public virtual int GetPageLength(string url)
        {
            var client = new HttpClient();
            if (client != null)
            {
                var response = client.GetAsync(url).Result;
                var body = response.Content.ReadAsStringAsync().Result;
                return body.Length;
            }

            return -1;
        }
    }
}