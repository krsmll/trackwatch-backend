using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using BLL.App.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// WatchListsController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WatchListsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// WatchListsController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public WatchListsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/WatchLists
        /// <summary>
        /// Get all watch lists
        /// </summary>
        /// <returns>All watch lists</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WatchList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.WatchList>>> GetWatchLists()
        {
            var all = await _bll.WatchLists.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.WatchList>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<WatchList, PublicApi.DTO.v1.WatchList>(item!));   
            }

            return Ok(res);
        }

        // GET: api/WatchLists/5
        /// <summary>
        /// Get watch list by ID
        /// </summary>
        /// <param name="id">Watch list ID</param>
        /// <returns>Watch list with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WatchList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.WatchList>> GetWatchList(Guid id)
        {
            var watchList = await _bll.WatchLists.FirstOrDefaultAsync(id);

            if (watchList == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<WatchList, PublicApi.DTO.v1.WatchList>(watchList!));
        }
        
        // GET: api/WatchLists/user/5
        /// <summary>
        /// Get watch list by username.
        /// </summary>
        /// <param name="username">App user username</param>
        /// <returns></returns>
        [HttpGet("user/{username}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WatchList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.WatchList>> GetFavCharacterListByUsername(string username)
        {
            var watchList = await _bll.WatchLists.FirstOrDefaultUserAsync(username);

            if (watchList == default)
            {
                return NotFound();
            }

            var res = _mapper.Map<WatchList, PublicApi.DTO.v1.WatchList>(watchList!);

            return Ok(res);
        }

        // PUT: api/WatchLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update watch list by ID
        /// </summary>
        /// <param name="id">Watch list ID</param>
        /// <param name="watchList">Updated watch list</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutWatchList(Guid id, PublicApi.DTO.v1.WatchList watchList)
        {
            if (id != watchList.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.WatchList, WatchList>(watchList!);
            _bll.WatchLists.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/WatchLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a watch list
        /// </summary>
        /// <param name="watchList">Watch list to add</param>
        /// <returns>Created watch list</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Genre>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.WatchList>> PostWatchList(PublicApi.DTO.v1.WatchList watchList)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.WatchList, WatchList>(watchList);
            
            var res = _bll.WatchLists.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetWatchList", new
            {
                id = watchList.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/WatchLists/5
        /// <summary>
        /// Delete a watch list by ID
        /// </summary>
        /// <param name="id">Watch list ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWatchList(Guid id)
        {
            var watchList = await _bll.WatchLists.FirstOrDefaultAsync(id);

            if (watchList == null)
            {
                return NotFound();
            }
            
            _bll.WatchLists.Remove(watchList!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> WatchListExists(Guid id)
        {
            return await _bll.WatchLists.ExistsAsync(id);
        }
    }
}