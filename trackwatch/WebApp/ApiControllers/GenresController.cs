using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Genres Controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// Genres Controller constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public GenresController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/Genres
        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns>All genres</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Genre>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Genre>>> GetGenres()
        {
            var all = await _bll.Genres.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.Genre>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<Genre, PublicApi.DTO.v1.Genre>(item!));   
            }

            return Ok(res);
        }

        // GET: api/Genres/5
        /// <summary>
        /// Get genre by ID
        /// </summary>
        /// <param name="id">Genre ID</param>
        /// <returns>Genre with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Genre>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.Genre>> GetGenre(Guid id)
        {
            var genre = await _bll.Genres.FirstOrDefaultAsync(id);

            if (genre == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<Genre, PublicApi.DTO.v1.Genre>(genre!));
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update genre by ID
        /// </summary>
        /// <param name="id">Genre ID</param>
        /// <param name="genre">Updated genre</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutGenre(Guid id, PublicApi.DTO.v1.Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.Genre, Genre>(genre!);
            _bll.Genres.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add genre
        /// </summary>
        /// <param name="genre">Genre to add</param>
        /// <returns>Created genre</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Genre>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.Genre>> PostGenre(PublicApi.DTO.v1.Genre genre)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.Genre, Genre>(genre);
            
            var res = _bll.Genres.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetGenre", new
            {
                id = genre.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/Genres/5
        /// <summary>
        /// Delete genre by ID
        /// </summary>
        /// <param name="id">Genre ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var genre = await _bll.Genres.FirstOrDefaultAsync(id);
            
            if (genre == null)
            {
                return NotFound();
            }

            _bll.Genres.Remove(genre!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> GenreExists(Guid id)
        {
            return await _bll.Genres.ExistsAsync(id);
        }
    }
}