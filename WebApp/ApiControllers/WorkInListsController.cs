using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using BLL.App.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// WorkInListsController
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkInListsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// WorkInListsController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public WorkInListsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/WorkInLists
        /// <summary>
        /// Get all works in lists
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkInList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.WorkInList>>> GetWorkInLists()
        {
            var all = await _bll.WorkInLists.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.WorkInList>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<WorkInList, PublicApi.DTO.v1.WorkInList>(item!));   
            }

            return Ok(res);
        }

        // GET: api/WorkInLists/5
        /// <summary>
        /// Get work in list by ID
        /// </summary>
        /// <param name="id">Work in list ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkInList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkInList>> GetWorkInList(Guid id)
        {
            var workInList = await _bll.WorkInLists.FirstOrDefaultAsync(id);

            if (workInList == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<WorkInList, PublicApi.DTO.v1.WorkInList>(workInList!));
        }

        // PUT: api/WorkInLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update work in list
        /// </summary>
        /// <param name="id">Work in list ID</param>
        /// <param name="workInList">Updated work in list</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutWorkInList(Guid id, PublicApi.DTO.v1.WorkInList workInList)
        {
            if (id != workInList.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.WorkInList, WorkInList>(workInList!);
            _bll.WorkInLists.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/WorkInLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add work in list
        /// </summary>
        /// <param name="workInList">Work in list to add</param>
        /// <returns>Created work in list</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.WorkInList>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.WorkInList>> PostWorkInList(PublicApi.DTO.v1.WorkInList workInList)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.WorkInList, WorkInList>(workInList);
            
            var res = _bll.WorkInLists.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetWorkInList", new
            {
                id = workInList.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/WorkInLists/5
        /// <summary>
        /// Delete work in list
        /// </summary>
        /// <param name="id">Work in list ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWorkInList(Guid id)
        {
            var workInList = await _bll.WorkInLists.FirstOrDefaultAsync(id);
            
            if (workInList == null)
            {
                return NotFound();
            }

            _bll.WorkInLists.Remove(workInList!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> WorkInListExists(Guid id)
        {
            return await _bll.WorkInLists.ExistsAsync(id);
        }
    }
}