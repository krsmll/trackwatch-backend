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
    /// WorkAuthorsController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkAuthorsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// WorkAuthorsController constructor
        /// </summary>
        /// <param name="bll"></param>
        /// <param name="mapper"></param>
        public WorkAuthorsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/WorkAuthors
        /// <summary>
        /// Get all work authors
        /// </summary>
        /// <returns>All work authors</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkAuthor>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.WorkAuthor>>> GetWorkAuthors()
        {
            var all = await _bll.WorkAuthors.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.WorkAuthor>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<WorkAuthor, PublicApi.DTO.v1.WorkAuthor>(item!));   
            }

            return Ok(res);
        }

        // GET: api/WorkAuthors/5
        /// <summary>
        /// Get work author by ID
        /// </summary>
        /// <param name="id">Work author ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Genre>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkAuthor>> GetWorkAuthor(Guid id)
        {
            var workAuthor = await _bll.WorkAuthors.FirstOrDefaultAsync(id);

            if (workAuthor == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<WorkAuthor, PublicApi.DTO.v1.WorkAuthor>(workAuthor!));
        }

        // PUT: api/WorkAuthors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update work author by ID
        /// </summary>
        /// <param name="id">Work author ID</param>
        /// <param name="workAuthor">Updated work author</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutWorkAuthor(Guid id, PublicApi.DTO.v1.WorkAuthor workAuthor)
        {
            if (id != workAuthor.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.WorkAuthor, WorkAuthor>(workAuthor!);
            _bll.WorkAuthors.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/WorkAuthors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add work author
        /// </summary>
        /// <param name="workAuthor">Work author to add</param>
        /// <returns>Created ork author</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkAuthor>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkAuthor>> PostWorkAuthor(PublicApi.DTO.v1.WorkAuthor workAuthor)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.WorkAuthor, WorkAuthor>(workAuthor);
            
            var res = _bll.WorkAuthors.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetWorkAuthor", new
            {
                id = workAuthor.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/WorkAuthors/5
        /// <summary>
        /// Delete work author
        /// </summary>
        /// <param name="id">Work author ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWorkAuthor(Guid id)
        {
            var workAuthor = await _bll.WorkAuthors.FirstOrDefaultAsync(id);
            
            if (workAuthor == null)
            {
                return NotFound();
            }

            _bll.WorkAuthors.Remove(workAuthor!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> WorkAuthorExists(Guid id)
        {
            return await _bll.WorkAuthors.ExistsAsync(id);
        }
    }
}