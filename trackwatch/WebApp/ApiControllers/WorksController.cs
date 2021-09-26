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
    /// WorksController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// WorksController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public WorksController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/Works
        /// <summary>
        /// Get all works
        /// </summary>
        /// <returns>All works</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Work>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Work>>> GetWorks()
        {
            var all = await _bll.Works.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.Work>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<Work, PublicApi.DTO.v1.Work>(item!));   
            }

            return Ok(res);
        }

        // GET: api/Works/5
        /// <summary>
        /// Get work by ID
        /// </summary>
        /// <param name="id">Work ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Work>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.Work>> GetWork(Guid id)
        {
            var work = await _bll.Works.FirstOrDefaultAsync(id);

            if (work == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<Work, PublicApi.DTO.v1.Work>(work!));
        }

        // PUT: api/Works/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update work by ID
        /// </summary>
        /// <param name="id">Work ID</param>
        /// <param name="work">Updated work</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutWork(Guid id, PublicApi.DTO.v1.Work work)
        {
            if (id != work.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.Work, Work>(work!);
            _bll.Works.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/Works
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add work
        /// </summary>
        /// <param name="work">Work to add</param>
        /// <returns>Created work</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Work>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.Work>> PostWork(PublicApi.DTO.v1.Work work)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.Work, Work>(work);
            
            var res = _bll.Works.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetWork", new
            {
                id = res.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/Works/5
        /// <summary>
        /// Delete work by ID
        /// </summary>
        /// <param name="id">Work ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWork(Guid id)
        {
            var work = await _bll.Works.FirstOrDefaultAsync(id);
            
            if (work == null)
            {
                return NotFound();
            }

            _bll.Works.Remove(work!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> WorkExists(Guid id)
        {
            return await _bll.Works.ExistsAsync(id);
        }
    }
}
