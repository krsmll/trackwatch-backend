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
    /// Fav Character Lists Controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class FavCharacterListsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// Fav Character Lists Controller
        /// </summary>
        /// <param name="bll"></param>
        /// <param name="mapper">mapper</param>
        public FavCharacterListsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/FavCharacterLists
        /// <summary>
        /// Get all favourite character lists
        /// </summary>
        /// <returns>All favourite character lists</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.FavCharacterList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.FavCharacterList>>> GetFavCharacterLists()
        {
            var all = await _bll.FavCharacterLists.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.FavCharacterList>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<FavCharacterList, PublicApi.DTO.v1.FavCharacterList>(item!));   
            }

            return Ok(res);
        }

        // GET: api/FavCharacterLists/5
        /// <summary>
        /// Get favourite character list by ID
        /// </summary>
        /// <param name="id">Favourite character list ID</param>
        /// <returns>Favourite character list with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.FavCharacterList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.FavCharacterList>> GetFavCharacterList(Guid id)
        {
            var fav = await _bll.FavCharacterLists.FirstOrDefaultAsync(id);

            if (fav == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<FavCharacterList, PublicApi.DTO.v1.FavCharacterList>(fav!));
        }
        
        // GET: api/FavCharacterLists/User/cool_username123
        /// <summary>
        /// Get favorite character list by username.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns></returns>
        [HttpGet("user/{username}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.FavCharacterList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.FavCharacterList>> GetFavCharacterListByUsername(string username)
        {
            var fav = await _bll.FavCharacterLists.FirstOrDefaultUserAsync(username);

            if (fav == default)
            {
                return NotFound();
            }

            var res = _mapper.Map<FavCharacterList, PublicApi.DTO.v1.FavCharacterList>(fav!);

            return Ok(res);
        }

        // PUT: api/FavCharacterLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update favourite character list
        /// </summary>
        /// <param name="id">Favourite character list ID</param>
        /// <param name="favCharacterList">Favourite character list to update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutFavCharacterList(Guid id, PublicApi.DTO.v1.FavCharacterList favCharacterList)
        {
            if (id != favCharacterList.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.FavCharacterList, FavCharacterList>(favCharacterList!);
            _bll.FavCharacterLists.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/FavCharacterLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add favourite character list
        /// </summary>
        /// <param name="favCharacterList">Favourite character list to add</param>
        /// <returns>Added favourite character list</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CoverPicture>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.FavCharacterList>> PostFavCharacterList(PublicApi.DTO.v1.FavCharacterList favCharacterList)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.FavCharacterList, FavCharacterList>(favCharacterList);
            
            var res = _bll.FavCharacterLists.Add(bll);
            await _bll.SaveChangesAsync();

            favCharacterList.Id = res.Id;
            return CreatedAtAction("GetFavCharacterList", new
            {
                id = bll.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, favCharacterList);
        }

        // DELETE: api/FavCharacterLists/5
        /// <summary>
        /// Delete favourite character list
        /// </summary>
        /// <param name="id">Favourite character list ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFavCharacterList(Guid id)
        {
            var favCharacterList = await _bll.FavCharacterLists.FirstOrDefaultAsync(id);
            
            if (favCharacterList == null)
            {
                return NotFound();
            }
            
            _bll.FavCharacterLists.Remove(favCharacterList!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> FavCharacterListExists(Guid id)
        {
            return await _bll.FavCharacterLists.ExistsAsync(id);
        }
    }
}