using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Character controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// Character controller
        /// </summary>
        /// <param name="bll">App BLL</param>
        /// <param name="mapper">IMapper</param>
        public CharactersController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/Characters
        /// <summary>
        /// Get all characters
        /// </summary>
        /// <returns>All characters</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Character>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Character>>> GetCharacters()
        {
            var all = await _bll.Characters.GetAllAsync(noTracking: false);
            var res = all.Select(item => _mapper.Map<Character, PublicApi.DTO.v1.Character>(item!)).ToList();

            return Ok(res);
        }

        // GET: api/Characters/5
        /// <summary>
        /// Get character by ID
        /// </summary>
        /// <param name="id">ID of the character</param>
        /// <returns>Character with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Character>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.Character>> GetCharacter(Guid id)
        {
            var character = await _bll.Characters.FirstOrDefaultAsync(id, noTracking: false);

            if (character == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<Character, PublicApi.DTO.v1.Character>(character!));
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update character.
        /// </summary>
        /// <param name="id">ID of the character</param>
        /// <param name="character">Character json</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutCharacter(Guid id, PublicApi.DTO.v1.Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.Character, Character>(character!);
            _bll.Characters.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add character
        /// </summary>
        /// <param name="character">Name of the character</param>
        /// <returns>The created character</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Character>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.Character>> PostCharacter(PublicApi.DTO.v1.Character character)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.Character, Character>(character);
            
            var res = _bll.Characters.Add(bll);
            await _bll.SaveChangesAsync();
            bll.Id = res.Id;

            return CreatedAtAction("GetCharacter", new
            {
                id = res.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/Characters/5
        /// <summary>
        /// Delete character by ID
        /// </summary>
        /// <param name="id">Character ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCharacter(Guid id)
        {
            var character = await _bll.Characters.FirstOrDefaultAsync(id);
            
            if (character == null)
            {
                return NotFound();
            }

            _bll.Characters.Remove(character!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> CharacterExists(Guid id)
        {
            return await _bll.Characters.ExistsAsync(id);
        }
    }
}