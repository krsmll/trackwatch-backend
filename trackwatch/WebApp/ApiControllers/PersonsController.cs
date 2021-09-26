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
    /// Persons Controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// Persons Controller constructor
        /// </summary>
        /// <param name="bll"></param>
        /// <param name="mapper"></param>
        public PersonsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/Persons
        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns>All persons</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Person>>> GetPersons()
        {
            var all = await _bll.Persons.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.Person>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<Person, PublicApi.DTO.v1.Person>(item!));   
            }

            return Ok(res);
        }

        // GET: api/Persons/5
        /// <summary>
        /// Get a person with specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.Person>> GetPerson(Guid id)
        {
            var person = await _bll.Persons.FirstOrDefaultAsync(id);

            if (person == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<Person, PublicApi.DTO.v1.Person>(person!));
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update person
        /// </summary>
        /// <param name="id">Person ID</param>
        /// <param name="person">Updated person</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutPerson(Guid id, PublicApi.DTO.v1.Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.Person, Person>(person!);
            _bll.Persons.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/Persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a person
        /// </summary>
        /// <param name="person">Person to add</param>
        /// <returns>Created person</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Genre>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.Person>> PostPerson(PublicApi.DTO.v1.Person person)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.Person, Person>(person);
            
            var res = _bll.Persons.Add(bll);
            await _bll.SaveChangesAsync();
            bll.Id = res.Id;

            return CreatedAtAction("GetPerson", new
            {
                id = bll.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/Persons/5
        /// <summary>
        /// Delete person
        /// </summary>
        /// <param name="id">Person ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var person = await _bll.Persons.FirstOrDefaultAsync(id);

            if (person == null)
            {
                return NotFound();
            }
            
            _bll.Persons.Remove(person!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> PersonExists(Guid id)
        {
            return await _bll.Persons.ExistsAsync(id);
        }
    }
}