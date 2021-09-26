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
    /// Person Pictures Controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PersonPicturesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// Person Pictures Controller constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public PersonPicturesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/PersonPictures
        /// <summary>
        /// Get all person pictures
        /// </summary>
        /// <returns>All person pictures</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.PersonPicture>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.PersonPicture>>> GetPersonPictures()
        {
            var all = await _bll.PersonPictures.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.PersonPicture>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<PersonPicture, PublicApi.DTO.v1.PersonPicture>(item!));   
            }

            return Ok(res);
        }

        // GET: api/PersonPictures/5
        /// <summary>
        /// Get a specific person picture by ID
        /// </summary>
        /// <param name="id">Person picture ID</param>
        /// <returns>Person picture with a specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.PersonPicture>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.PersonPicture>> GetPersonPicture(Guid id)
        {
            var personPicture = await _bll.PersonPictures.FirstOrDefaultAsync(id);

            if (personPicture == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<PersonPicture, PublicApi.DTO.v1.PersonPicture>(personPicture!));
        }

        // PUT: api/PersonPictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update person picture
        /// </summary>
        /// <param name="id">Person picture ID</param>
        /// <param name="personPicture">Updated person picture</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutPersonPicture(Guid id, PublicApi.DTO.v1.PersonPicture personPicture)
        {
            if (id != personPicture.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.PersonPicture, PersonPicture>(personPicture!);
            _bll.PersonPictures.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/PersonPictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add person picture
        /// </summary>
        /// <param name="personPicture">Person picture to add</param>
        /// <returns>Created person picture</returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.DTO.v1.PersonPicture>> PostPersonPicture(PublicApi.DTO.v1.PersonPicture personPicture)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.PersonPicture, PersonPicture>(personPicture);
            
            var res = _bll.PersonPictures.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetPersonPicture", new
            {
                id = personPicture.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/PersonPictures/5
        /// <summary>
        /// Delete person picture
        /// </summary>
        /// <param name="id">Person picture ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePersonPicture(Guid id)
        {
            var personPicture = await _bll.PersonPictures.FirstOrDefaultAsync(id);

            _bll.PersonPictures.Remove(personPicture!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> PersonPictureExists(Guid id)
        {
            return await _bll.PersonPictures.ExistsAsync(id);
        }
    }
}