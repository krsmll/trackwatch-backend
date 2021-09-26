using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.App.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// CharacterPersons
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CharacterPersonsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// CharacterPersonsController
        /// </summary>
        /// <param name="bll"></param>
        /// <param name="mapper"></param>
        /// 
        
        public CharacterPersonsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/CharacterPersons
        /// <summary>
        /// Get all character persons.
        /// </summary>
        /// <returns>Character persons</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterPerson>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<CharacterPerson>>> GetCharacterPersons()
        {
            var all = await _bll.CharacterPersons.GetAllAsync(noTracking: false);
            var res = all.Select(item => _mapper.Map<CharacterPerson, PublicApi.DTO.v1.CharacterPerson>(item!)).ToList();

            return Ok(res);
        }

        // GET: api/CharacterPersons/5
        /// <summary>
        /// Get a specific character person.
        /// </summary>
        /// <param name="id">Character person ID</param>
        /// <returns>A character person with specific ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterPerson>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CharacterPerson>> GetCharacterPerson(Guid id)
        {
            var characterPerson = await _bll.CharacterPersons.FirstOrDefaultAsync(id);
            if (characterPerson == default)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CharacterPerson, PublicApi.DTO.v1.CharacterPerson>(characterPerson!));
        }

        // PUT: api/CharacterPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updated a character person by ID
        /// </summary>
        /// <param name="id">Character person ID</param>
        /// <param name="characterPerson">Updated character person</param>
        /// <returns>OK</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCharacterPerson(Guid id, PublicApi.DTO.v1.CharacterPerson characterPerson)
        {
            if (id != characterPerson.Id)
            {
                return BadRequest();
            }

            var item = _mapper.Map<PublicApi.DTO.v1.CharacterPerson, CharacterPerson>(characterPerson!);
            _bll.CharacterPersons.Update(item);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        // POST: api/CharacterPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add character person
        /// </summary>
        /// <param name="characterPerson">Character person to add</param>
        /// <returns>Added character</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterPerson>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CharacterPerson>> PostCharacterPerson(PublicApi.DTO.v1.CharacterPerson characterPerson)
        {
            var item = _mapper.Map<PublicApi.DTO.v1.CharacterPerson, CharacterPerson>(characterPerson!);
            var res = _bll.CharacterPersons.Add(item);
            await _bll.SaveChangesAsync();

            characterPerson.Id = res.Id;
            return CreatedAtAction("GetCharacterPerson", new
            {
                id = characterPerson.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, characterPerson);
        }

        // DELETE: api/CharacterPersons/5
        /// <summary>
        /// Delete a character person by ID
        /// </summary>
        /// <param name="id">Character person ID</param>
        /// <returns>OK</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCharacterPerson(Guid id)
        {
            var characterPerson = await _bll.CharacterPersons.FirstOrDefaultAsync(id);
            if (characterPerson == null)
            {
                return NotFound();
            }

            _bll.CharacterPersons.Remove(characterPerson!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> CharacterPersonExists(Guid id)
        {
            return await _bll.CharacterPersons.ExistsAsync(id);
        }
    }
}
