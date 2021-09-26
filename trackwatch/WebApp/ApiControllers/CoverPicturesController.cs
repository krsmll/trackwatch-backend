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
    /// Cover picture controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CoverPicturesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        
        /// <summary>
        /// Cover picture controller constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public CoverPicturesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/CoverPictures
        /// <summary>
        /// Get all cover pictures
        /// </summary>
        /// <returns>All cover pictures</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CoverPicture>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.CoverPicture>>> GetCoverPictures()
        {
            var all = await _bll.CoverPictures.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.CoverPicture>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<CoverPicture, PublicApi.DTO.v1.CoverPicture>(item!));   
            }

            return Ok(res);
        }

        // GET: api/CoverPictures/5
        /// <summary>
        /// Get a cover picture by ID
        /// </summary>
        /// <param name="id">Cover picture ID</param>
        /// <returns>Cover picture</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CoverPicture>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.CoverPicture>> GetCoverPicture(Guid id)
        {
            var coverPicture = await _bll.CoverPictures.FirstOrDefaultAsync(id);

            if (coverPicture == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<CoverPicture, PublicApi.DTO.v1.CoverPicture>(coverPicture!));
        }

        // PUT: api/CoverPictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update cover picture by ID
        /// </summary>
        /// <param name="id">Cover picture ID</param>
        /// <param name="coverPicture">Updated cover picture</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutCoverPicture(Guid id, PublicApi.DTO.v1.CoverPicture coverPicture)
        {
            if (id != coverPicture.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.CoverPicture, CoverPicture>(coverPicture!);
            _bll.CoverPictures.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/CoverPictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add cover picture
        /// </summary>
        /// <param name="coverPicture">Cover picture to add</param>
        /// <returns>Created cover picture</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.CoverPicture>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.CoverPicture>> PostCoverPicture(PublicApi.DTO.v1.CoverPicture coverPicture)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.CoverPicture, CoverPicture>(coverPicture);
            
            var res = _bll.CoverPictures.Add(bll);
            await _bll.SaveChangesAsync();

            coverPicture.Id = res.Id;
            return CreatedAtAction("GetCoverPicture", new
            {
                id = bll.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, coverPicture);
        }

        // DELETE: api/CoverPictures/5
        /// <summary>
        /// Delete cover picture
        /// </summary>
        /// <param name="id">Cover picture ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCoverPicture(Guid id)
        {
            var coverPicture = await _bll.CoverPictures.FirstOrDefaultAsync(id);
            
            if (coverPicture == null)
            {
                return NotFound();
            }

            _bll.CoverPictures.Remove(coverPicture!);
            await _bll.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> CoverPictureExists(Guid id)
        {
            return await _bll.CoverPictures.ExistsAsync(id);
        }
    }
}