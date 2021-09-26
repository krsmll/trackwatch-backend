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
    /// 
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CharacterInListsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// Relations between characters and user favorite character lists controller.
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public CharacterInListsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/CharacterInLists
        /// <summary>
        /// Get all relations between characters and user favorite character lists.
        /// </summary>
        /// <returns>All relations between characters and user favorite character lists.</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterInList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.CharacterInList>>> GetCharacterInLists()
        {
            var all = await _bll.CharacterInLists.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.CharacterInList>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<CharacterInList, PublicApi.DTO.v1.CharacterInList>(item!));   
            }

            return Ok(res);
        }

        // GET: api/CharacterInLists/5
        /// <summary>
        /// Get a specific character and user favorite character list relation by ID.
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Relation between a character and a user favorite character list.</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterInList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.CharacterInList>> GetCharacterInList(Guid id)
        {
            var characterInList = await _bll.CharacterInLists.FirstOrDefaultAsync(id);
            if (characterInList == default)
            {
                return NotFound();
            }
            return _mapper.Map<CharacterInList, PublicApi.DTO.v1.CharacterInList>(characterInList!);
        }

        // PUT: api/CharacterInLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update character in list
        /// </summary>
        /// <param name="id">Character in list ID</param>
        /// <param name="characterInList">New edited character in list</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterInList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCharacterInList(Guid id, PublicApi.DTO.v1.CharacterInList characterInList)
        {
            if (id != characterInList.Id)
            {
                return BadRequest();
            }

            var cil = _mapper.Map<PublicApi.DTO.v1.CharacterInList, CharacterInList>(characterInList!);
            _bll.CharacterInLists.Update(cil);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        // POST: api/CharacterInLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add character in list
        /// </summary>
        /// <param name="characterInList">Character to add</param>
        /// <returns>Created character</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CharacterInList>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.CharacterInList>> PostCharacterInList(CharacterInList characterInList)
        {
            var res = _bll.CharacterInLists.Add(characterInList);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetCharacterInList", new
            {
                id = res.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, characterInList);
        }

        // DELETE: api/CharacterInLists/5
        /// <summary>
        /// Delete character in list
        /// </summary>
        /// <param name="id">Character ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCharacterInList(Guid id)
        {
            var characterInList = await _bll.CharacterInLists.FirstOrDefaultAsync(id);
            
            if (characterInList == null)
            {
                return NotFound();
            }

            _bll.CharacterInLists.Remove(characterInList!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> CharacterInListExists(Guid id)
        {
            return await _bll.CharacterInLists.ExistsAsync(id);
        }
    }
}