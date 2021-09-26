using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingScale = BLL.App.DTO.RatingScale;

namespace WebApp.Controllers
{
    /// <summary>
    /// RatingScalesController
    /// </summary>
    public class RatingScalesController : Controller
    {

        private readonly IAppBLL _bll;
        
        /// <summary>
        /// RatingScalesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public RatingScalesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: RatingScales
        /// <summary>
        /// Rating scales index view. List all rating scales.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.RatingScales.GetAllAsync());
        }

        // GET: RatingScales/Details/5
        /// <summary>
        /// Detailed view of rating scale.
        /// </summary>
        /// <param name="id">Rating scale ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingScale = await _bll.RatingScales.FirstOrDefaultAsync(id.Value);
            if (ratingScale == null)
            {
                return NotFound();
            }

            return View(ratingScale);
        }

        // GET: RatingScales/Create
        /// <summary>
        /// Rating scale creation view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: RatingScales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create rating scale
        /// </summary>
        /// <param name="ratingScale">Created rating scale</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MinValue,MaxValue")] RatingScale ratingScale)
        {
            if (ModelState.IsValid)
            {
                ratingScale.Id = Guid.NewGuid();
                _bll.RatingScales.Add(ratingScale);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ratingScale);
        }

        // GET: RatingScales/Edit/5
        /// <summary>
        /// Rating scale edit view
        /// </summary>
        /// <param name="id">Rating scale ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingScale = await _bll.RatingScales.FirstOrDefaultAsync(id.Value);
            return View(ratingScale);
        }

        // POST: RatingScales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit rating scale
        /// </summary>
        /// <param name="id">Rating scale ID</param>
        /// <param name="ratingScale">Updated rating scale</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MinValue,MaxValue")] RatingScale ratingScale)
        {
            if (id != ratingScale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.RatingScales.Update(ratingScale);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RatingScaleExists(ratingScale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ratingScale);
        }

        // GET: RatingScales/Delete/5
        /// <summary>
        /// Rating scale deletion view
        /// </summary>
        /// <param name="id">Rating scale ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingScale = await _bll.RatingScales.FirstOrDefaultAsync(id.Value);

            return View(ratingScale);
        }

        // POST: RatingScales/Delete/5
        /// <summary>
        /// Delete rating scale
        /// </summary>
        /// <param name="id">Rating scale ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ratingScale = await _bll.RatingScales.FirstOrDefaultAsync(id);
            _bll.RatingScales.Remove(ratingScale!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RatingScaleExists(Guid id)
        {
            return await _bll.RatingScales.ExistsAsync(id);
        }
    }
}
