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
    /// Format controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;


        /// <summary>
        /// Format controller constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public FormatsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/Formats
        /// <summary>
        /// Get all formats
        /// </summary>
        /// <returns>All formats</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Format>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Format>>> GetFormats()
        {
            var all = await _bll.Formats.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.Format>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<Format, PublicApi.DTO.v1.Format>(item!));   
            }

            return Ok(res);
        }

        // GET: api/Formats/5
        /// <summary>
        /// Get format by ID
        /// </summary>
        /// <param name="id">Format ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Format>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.Format>> GetFormat(Guid id)
        {
            var format = await _bll.Formats.FirstOrDefaultAsync(id);

            if (format == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<Format, PublicApi.DTO.v1.Format>(format!));
        }

        // PUT: api/Formats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update format by ID
        /// </summary>
        /// <param name="id">Format ID</param>
        /// <param name="format">Updated format</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutFormat(Guid id, PublicApi.DTO.v1.Format format)
        {
            if (id != format.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.Format, Format>(format!);
            _bll.Formats.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/Formats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add format
        /// </summary>
        /// <param name="format">Format to add</param>
        /// <returns>Created format</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Format>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.Format>> PostFormat(PublicApi.DTO.v1.Format format)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.Format, Format>(format);
            
            var res = _bll.Formats.Add(bll);
            await _bll.SaveChangesAsync();

            format.Id = res.Id;
            return CreatedAtAction("GetFormat", new
            {
                id = bll.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, format);
        }

        // DELETE: api/Formats/5
        /// <summary>
        /// Delete format by ID
        /// </summary>
        /// <param name="id">Format ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFormat(Guid id)
        {
            var format = await _bll.Formats.FirstOrDefaultAsync(id);
            
            if (format == null)
            {
                return NotFound();
            }

            _bll.Formats.Remove(format!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> FormatExists(Guid id)
        {
            return await _bll.Formats.ExistsAsync(id);
        }
    }
}