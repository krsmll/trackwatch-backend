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
    /// RolesController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// RolesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public RolesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/Roles
        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns>All roles</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Role>>> GetRoles()
        {
            var all = await _bll.Roles.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.Role>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<Role, PublicApi.DTO.v1.Role>(item!));   
            }

            return Ok(res);
        }

        // GET: api/Roles/5
        /// <summary>
        /// Get role by ID
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <returns>Role with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.Role>> GetRole(Guid id)
        {
            var role = await _bll.Roles.FirstOrDefaultAsync(id);

            if (role == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<Role, PublicApi.DTO.v1.Role>(role!));
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <param name="role">Updated role</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutRole(Guid id, PublicApi.DTO.v1.Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.Role, Role>(role!);
            _bll.Roles.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a role
        /// </summary>
        /// <param name="role">Role to add</param>
        /// <returns>Created role</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Role>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.Role>> PostRole(PublicApi.DTO.v1.Role role)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.Role, Role>(role);
            
            var res = _bll.Roles.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetRole", new
            {
                id = role.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/Roles/5
        /// <summary>
        /// Delete a role by ID
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var role = await _bll.Roles.FirstOrDefaultAsync(id);
            
            if (role == null)
            {
                return NotFound();
            }

            _bll.Roles.Remove(role!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> RoleExists(Guid id)
        {
            return await _bll.Roles.ExistsAsync(id);
        }
    }
}