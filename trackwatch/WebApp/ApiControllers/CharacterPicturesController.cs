using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Character picture controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CharacterPicturesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// Character picture controller constructor
        /// </summary>
        /// <param name="bll"></param>
        /// <param name="mapper"></param>
        public CharacterPicturesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/CharacterPictures
        /// <summary>
        /// Get all character pictures
        /// </summary>
        /// <returns>All character pictures</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterPicture>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.CharacterPicture>>> GetCharacterPictures()
        {
            var all = await _bll.Characters.GetAllAsync(noTracking: false);
            var res = all.Select(item => _mapper.Map<Character, PublicApi.DTO.v1.Character>(item!)).ToList();

            return Ok(res);
        }

        // GET: api/CharacterPictures/5
        /// <summary>
        /// Get a character picture by ID
        /// </summary>
        /// <param name="id">Character picture ID</param>
        /// <returns>A character with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterPicture>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.CharacterPicture>> GetCharacterPicture(Guid id)
        {
            var characterPicture = await _bll.CharacterPictures.FirstOrDefaultAsync(id);
            if (characterPicture == default)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CharacterPicture, PublicApi.DTO.v1.CharacterPicture>(characterPicture!));
        }

        // PUT: api/CharacterPictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update a character picture by ID
        /// </summary>
        /// <param name="id">Character picture ID</param>
        /// <param name="characterPicture">Updated character picture</param>
        /// <returns>OK</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCharacterPicture(Guid id,
            PublicApi.DTO.v1.CharacterPicture characterPicture)
        {
            if (id != characterPicture.Id)
            {
                return BadRequest();
            }

            var item = _mapper.Map<PublicApi.DTO.v1.CharacterPicture, CharacterPicture>(characterPicture!);
            _bll.CharacterPictures.Update(item);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        // POST: api/CharacterPictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add character picture
        /// </summary>
        /// <param name="characterPicture">Character picture to add</param>
        /// <returns>Created character picture</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterPicture>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublicApi.DTO.v1.CharacterPicture>> PostCharacterPicture(
            PublicApi.DTO.v1.CharacterPicture characterPicture)
        {
            var item = _mapper.Map<PublicApi.DTO.v1.CharacterPicture, CharacterPicture>(characterPicture!);
            var res = _bll.CharacterPictures.Add(item);
            await _bll.SaveChangesAsync();

            characterPicture.Id = res.Id;
            return CreatedAtAction("GetCharacterPicture", new
            {
                id = characterPicture.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, characterPicture);
        }

        // DELETE: api/CharacterPictures/5
        /// <summary>
        /// Delete a character picture by ID.
        /// </summary>
        /// <param name="id">Character picture ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCharacterPicture(Guid id)
        {
            var characterPicture = await _bll.CharacterPictures.FirstOrDefaultAsync(id);
            if (characterPicture == null)
            {
                return NotFound();
            }

            _bll.CharacterPictures.Remove(characterPicture!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> CharacterPictureExists(Guid id)
        {
            return await _bll.CharacterPictures.ExistsAsync(id);
        }
    }
}