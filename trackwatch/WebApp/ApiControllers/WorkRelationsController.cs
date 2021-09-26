using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// WorkRelationsController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkRelationsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// WorkRelationsController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public WorkRelationsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/WorkRelations
        /// <summary>
        /// Get all work relations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkRelation>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.WorkRelation>>> GetWorkRelations()
        {
            var all = await _bll.WorkRelations.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.WorkRelation>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<WorkRelation, PublicApi.DTO.v1.WorkRelation>(item!));   
            }

            return Ok(res);
        }

        // GET: api/WorkRelations/5
        /// <summary>
        /// Get work relation by ID
        /// </summary>
        /// <param name="id">Work relation ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkRelation>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkRelation>> GetWorkRelation(Guid id)
        {
            var workRelation = await _bll.WorkRelations.FirstOrDefaultAsync(id);

            if (workRelation == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<WorkRelation, PublicApi.DTO.v1.WorkRelation>(workRelation!));
        }

        // PUT: api/WorkRelations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update work relation
        /// </summary>
        /// <param name="id">Work relation ID</param>
        /// <param name="workRelation">Updated work relation</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutWorkRelation(Guid id, PublicApi.DTO.v1.WorkRelation workRelation)
        {
            if (id != workRelation.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.WorkRelation, WorkRelation>(workRelation!);
            _bll.WorkRelations.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/WorkRelations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add work relation
        /// </summary>
        /// <param name="workRelation">Work relation to add</param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkRelation>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkRelation>> PostWorkRelation(PublicApi.DTO.v1.WorkRelation workRelation)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.WorkRelation, WorkRelation>(workRelation);
            
            var res = _bll.WorkRelations.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetWorkRelation", new
            {
                id = workRelation.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/WorkRelations/5
        /// <summary>
        /// Delete work relation
        /// </summary>
        /// <param name="id">Work relation ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWorkRelation(Guid id)
        {
            var workRelation = await _bll.WorkRelations.FirstOrDefaultAsync(id);
            
            if (workRelation == null)
            {
                return NotFound();
            }

            _bll.WorkRelations.Remove(workRelation!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> WorkRelationExists(Guid id)
        {
            return await _bll.WorkRelations.ExistsAsync(id);
        }
    }
}
