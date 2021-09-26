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
    /// WorkCharactersController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkCharactersController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// WorkCharactersController constructor
        /// </summary>
        /// <param name="bll"></param>
        /// <param name="mapper"></param>
        public WorkCharactersController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/WorkCharacters
        /// <summary>
        /// Get all work characters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkCharacter>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.WorkCharacter>>> GetWorkCharacters()
        {
            var all = await _bll.WorkCharacters.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.WorkCharacter>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<WorkCharacter, PublicApi.DTO.v1.WorkCharacter>(item!));   
            }

            return Ok(res);
        }

        // GET: api/WorkCharacters/5
        /// <summary>
        /// Get work character by ID
        /// </summary>
        /// <param name="id">Work character ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkCharacter>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkCharacter>> GetWorkCharacter(Guid id)
        {
            var workCharacter = await _bll.WorkCharacters.FirstOrDefaultAsync(id);

            if (workCharacter == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<WorkCharacter, PublicApi.DTO.v1.WorkCharacter>(workCharacter!));
        }

        // PUT: api/WorkCharacters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update work character by ID
        /// </summary>
        /// <param name="id">Work character ID</param>
        /// <param name="workCharacter">Updated work character</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutWorkCharacter(Guid id, PublicApi.DTO.v1.WorkCharacter workCharacter)
        {
            if (id != workCharacter.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.WorkCharacter, WorkCharacter>(workCharacter!);
            _bll.WorkCharacters.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/WorkCharacters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add work character
        /// </summary>
        /// <param name="workCharacter">Work character to add</param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkCharacter>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkCharacter>> PostWorkCharacter(PublicApi.DTO.v1.WorkCharacter workCharacter)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.WorkCharacter, WorkCharacter>(workCharacter);
            
            var res = _bll.WorkCharacters.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetWorkCharacter", new
            {
                id = workCharacter.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/WorkCharacters/5
        /// <summary>
        /// Delete work character by ID
        /// </summary>
        /// <param name="id">Work character ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWorkCharacter(Guid id)
        {
            var workCharacter = await _bll.WorkCharacters.FirstOrDefaultAsync(id);
            
            if (workCharacter == null)
            {
                return NotFound();
            }

            _bll.WorkCharacters.Remove(workCharacter!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> WorkCharacterExists(Guid id)
        {
            return await _bll.WorkCharacters.ExistsAsync(id);
        }
    }
}