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
    /// WorkTypesController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkTypesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// WorkTypesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public WorkTypesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/WorkTypes
        /// <summary>
        /// Get all work types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.WorkType>>> GetTypes()
        {
            var all = await _bll.WorkTypes.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.WorkType>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<WorkType, PublicApi.DTO.v1.WorkType>(item!));   
            }

            return Ok(res);
        }

        // GET: api/WorkTypes/5
        /// <summary>
        /// Get work type by ID
        /// </summary>
        /// <param name="id">Work type ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkType>> GetWorkType(Guid id)
        {
            var workType = await _bll.WorkTypes.FirstOrDefaultAsync(id);

            if (workType == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<WorkType, PublicApi.DTO.v1.WorkType>(workType!));
        }

        // PUT: api/WorkTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update work type by ID
        /// </summary>
        /// <param name="id">Work type ID</param>
        /// <param name="workType">Updated work type</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutWorkType(Guid id, PublicApi.DTO.v1.WorkType workType)
        {
            if (id != workType.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.WorkType, WorkType>(workType!);
            _bll.WorkTypes.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/WorkTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add work type
        /// </summary>
        /// <param name="workType">Work type to add</param>
        /// <returns>Created work type</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkType>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkType>> PostWorkType(PublicApi.DTO.v1.WorkType workType)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.WorkType, WorkType>(workType);
            
            var res = _bll.WorkTypes.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetWorkType", new
            {
                id = workType.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/WorkTypes/5
        /// <summary>
        /// Delete work type by ID
        /// </summary>
        /// <param name="id">Work type ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWorkType(Guid id)
        {
            var workType = await _bll.WorkTypes.FirstOrDefaultAsync(id);
            
            if (workType == null)
            {
                return NotFound();
            }

            _bll.WorkTypes.Remove(workType!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> WorkTypeExists(Guid id)
        {
            return await _bll.WorkTypes.ExistsAsync(id);
        }
    }
}
