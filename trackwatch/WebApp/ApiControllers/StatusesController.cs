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
    /// StatusesController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// StatusesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public StatusesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/Statuses
        /// <summary>
        /// Get all statuses
        /// </summary>
        /// <returns>All statuses</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Status>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Status>>> GetStatuses()
        {
            var all = await _bll.Statuses.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.Status>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<Status, PublicApi.DTO.v1.Status>(item!));   
            }

            return Ok(res);
        }

        // GET: api/Statuses/5
        /// <summary>
        /// Get a status by ID
        /// </summary>
        /// <param name="id">Status ID</param>
        /// <returns>Status with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Status>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.Status>> GetStatus(Guid id)
        {
            var status = await _bll.Statuses.FirstOrDefaultAsync(id);

            if (status == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<Status, PublicApi.DTO.v1.Status>(status!));
        }

        // PUT: api/Statuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update status by ID
        /// </summary>
        /// <param name="id">Status ID</param>
        /// <param name="status">Updated status</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutStatus(Guid id, PublicApi.DTO.v1.Status status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.Status, Status>(status!);
            _bll.Statuses.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/Statuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add status
        /// </summary>
        /// <param name="status">Status to add</param>
        /// <returns>Created status</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Status>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.Status>> PostStatus(PublicApi.DTO.v1.Status status)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.Status, Status>(status);
            
            var res = _bll.Statuses.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetStatus", new
            {
                id = status.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/Statuses/5
        /// <summary>
        /// Delete status by ID
        /// </summary>
        /// <param name="id">Status ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStatus(Guid id)
        {
            var status = await _bll.Statuses.FirstOrDefaultAsync(id);
            
            if (status == null)
            {
                return NotFound();
            }

            _bll.Statuses.Remove(status!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> StatusExists(Guid id)
        {
            return await _bll.Statuses.ExistsAsync(id);
        }
    }
}