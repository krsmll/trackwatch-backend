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
    /// WorkAuthorRolesController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkAuthorRolesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// WorkAuthorRolesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public WorkAuthorRolesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/WorkAuthorRoles
        /// <summary>
        /// Get all work author roles
        /// </summary>
        /// <returns>All work author roles</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkAuthorRole>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.WorkAuthorRole>>> GetWorkAuthorRoles()
        {
            var all = await _bll.WorkAuthorRoles.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.WorkAuthorRole>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<WorkAuthorRole, PublicApi.DTO.v1.WorkAuthorRole>(item!));   
            }

            return Ok(res);
        }

        // GET: api/WorkAuthorRoles/5
        /// <summary>
        /// Get a work author role by ID
        /// </summary>
        /// <param name="id">Work author role ID</param>
        /// <returns>Work author role with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkAuthorRole>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkAuthorRole>> GetWorkAuthorRole(Guid id)
        {
            var workAuthorRole = await _bll.WorkAuthorRoles.FirstOrDefaultAsync(id);

            if (workAuthorRole == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<WorkAuthorRole, PublicApi.DTO.v1.WorkAuthorRole>(workAuthorRole!));
        }

        // PUT: api/WorkAuthorRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update work author role by ID
        /// </summary>
        /// <param name="id">Work author role ID</param>
        /// <param name="workAuthorRole">Updated work author role</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutWorkAuthorRole(Guid id, PublicApi.DTO.v1.WorkAuthorRole workAuthorRole)
        {
            if (id != workAuthorRole.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.WorkAuthorRole, WorkAuthorRole>(workAuthorRole!);
            _bll.WorkAuthorRoles.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/WorkAuthorRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a work author role
        /// </summary>
        /// <param name="workAuthorRole">Work author role to add</param>
        /// <returns>Created work author role</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkAuthorRole>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkAuthorRole>> PostWorkAuthorRole(PublicApi.DTO.v1.WorkAuthorRole workAuthorRole)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.WorkAuthorRole, WorkAuthorRole>(workAuthorRole);
            
            var res = _bll.WorkAuthorRoles.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetWorkAuthorRole", new
            {
                id = workAuthorRole.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/WorkAuthorRoles/5
        /// <summary>
        /// Delete work author role by ID
        /// </summary>
        /// <param name="id">Work author role ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWorkAuthorRole(Guid id)
        {
            var workAuthorRole = await _bll.WorkAuthorRoles.FirstOrDefaultAsync(id);
            
            if (workAuthorRole == null)
            {
                return NotFound();
            }

            _bll.WorkAuthorRoles.Remove(workAuthorRole!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> WorkAuthorRoleExists(Guid id)
        {
            return await _bll.WorkAuthorRoles.ExistsAsync(id);
        }
    }
}