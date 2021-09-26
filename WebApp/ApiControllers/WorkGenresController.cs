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
    /// WorkGenresController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkGenresController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// WorkGenresController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public WorkGenresController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/WorkGenres
        /// <summary>
        /// Get all work genres
        /// </summary>
        /// <returns>All work genres</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkGenre>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.WorkGenre>>> GetWorkGenres()
        {
            var all = await _bll.WorkGenres.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.WorkGenre>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<WorkGenre, PublicApi.DTO.v1.WorkGenre>(item!));   
            }

            return Ok(res);
        }

        // GET: api/WorkGenres/5
        /// <summary>
        /// Get work genre by ID
        /// </summary>
        /// <param name="id">Work genre ID</param>
        /// <returns>Work genre with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkGenre>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkGenre>> GetWorkGenre(Guid id)
        {
            var workGenre = await _bll.WorkGenres.FirstOrDefaultAsync(id);

            if (workGenre == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<WorkGenre, PublicApi.DTO.v1.WorkGenre>(workGenre!));
        }

        // PUT: api/WorkGenres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update work genre by ID
        /// </summary>
        /// <param name="id">Work genre ID</param>
        /// <param name="workGenre">Updated work genre</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutWorkGenre(Guid id, PublicApi.DTO.v1.WorkGenre workGenre)
        {
            if (id != workGenre.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.WorkGenre, WorkGenre>(workGenre!);
            _bll.WorkGenres.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/WorkGenres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add work genre
        /// </summary>
        /// <param name="workGenre">Work genre to add</param>
        /// <returns>Created work genre</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkGenre>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkGenre>> PostWorkGenre(PublicApi.DTO.v1.WorkGenre workGenre)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.WorkGenre, WorkGenre>(workGenre);
            
            var res = _bll.WorkGenres.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetWorkGenre", new
            {
                id = workGenre.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/WorkGenres/5
        /// <summary>
        /// Delete work genre by ID
        /// </summary>
        /// <param name="id">Work genre ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWorkGenre(Guid id)
        {
            var workGenre = await _bll.WorkGenres.FirstOrDefaultAsync(id);
            
            if (workGenre == null)
            {
                return NotFound();
            }

            _bll.WorkGenres.Remove(workGenre!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> WorkGenreExists(Guid id)
        {
            return await _bll.WorkGenres.ExistsAsync(id);
        }
    }
}