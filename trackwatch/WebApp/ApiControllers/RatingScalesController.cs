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
    /// Rating Scales Controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class RatingScalesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        /// <summary>
        /// Rating Scales Controller constructor
        /// </summary>
        /// <param name="bll">bll</param>
        /// <param name="mapper">mapper</param>
        public RatingScalesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/RatingScales
        /// <summary>
        /// Get all rating scales
        /// </summary>
        /// <returns>All rating scales</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.RatingScale>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.RatingScale>>> GetRatingScales()
        {
            var all = await _bll.RatingScales.GetAllAsync();
            var res = new List<PublicApi.DTO.v1.RatingScale>();

            foreach (var item in all)
            {
                res.Add(_mapper.Map<RatingScale, PublicApi.DTO.v1.RatingScale>(item!));   
            }

            return Ok(res);
        }

        // GET: api/RatingScales/5
        /// <summary>
        /// Get rating scale by ID
        /// </summary>
        /// <param name="id">Rating scale ID</param>
        /// <returns>Rating scale with specified ID</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.RatingScale>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublicApi.DTO.v1.RatingScale>> GetRatingScale(Guid id)
        {
            var ratingScale = await _bll.RatingScales.FirstOrDefaultAsync(id);

            if (ratingScale == default)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<RatingScale, PublicApi.DTO.v1.RatingScale>(ratingScale!));
        }

        // PUT: api/RatingScales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update rating scale
        /// </summary>
        /// <param name="id">Rating scale ID</param>
        /// <param name="ratingScale">Updated rating scale</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutRatingScale(Guid id, PublicApi.DTO.v1.RatingScale ratingScale)
        {
            if (id != ratingScale.Id)
            {
                return BadRequest();
            }
            
            var item = _mapper.Map<PublicApi.DTO.v1.RatingScale, RatingScale>(ratingScale!);
            _bll.RatingScales.Update(item);
            await _bll.SaveChangesAsync();
            
            return Ok();
        }

        // POST: api/RatingScales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a rating scale
        /// </summary>
        /// <param name="ratingScale"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.RatingScale>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PublicApi.DTO.v1.RatingScale>> PostRatingScale(PublicApi.DTO.v1.RatingScale ratingScale)
        {
            var bll = _mapper.Map<PublicApi.DTO.v1.RatingScale, RatingScale>(ratingScale);
            
            var res = _bll.RatingScales.Add(bll);
            await _bll.SaveChangesAsync();

            bll.Id = res.Id;
            return CreatedAtAction("GetRatingScale", new
            {
                id = ratingScale.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
            }, bll);
        }

        // DELETE: api/RatingScales/5
        /// <summary>
        /// Delete rating scale by ID
        /// </summary>
        /// <param name="id">Rating scale ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRatingScale(Guid id)
        {
            var ratingScale = await _bll.RatingScales.FirstOrDefaultAsync(id);
            
            if (ratingScale == null)
            {
                return NotFound();
            }

            _bll.RatingScales.Remove(ratingScale!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> RatingScaleExists(Guid id)
        {
            return await _bll.RatingScales.ExistsAsync(id);
        }
    }
}