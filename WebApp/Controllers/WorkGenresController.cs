using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkGenre = BLL.App.DTO.WorkGenre;

namespace WebApp.Controllers
{
    /// <summary>
    /// WorkGenresController
    /// </summary>
    public class WorkGenresController : Controller
    {

        private readonly IAppBLL _bll;
        
        /// <summary>
        /// WorkGenresController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public WorkGenresController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkGenres
        /// <summary>
        /// Wonk genre index view. List all work genres.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.WorkGenres.GetAllAsync());
        }

        // GET: WorkGenres/Details/5
        /// <summary>
        /// Detailed view of work genre
        /// </summary>
        /// <param name="id">Work genre ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workGenre = await _bll.WorkGenres.FirstOrDefaultAsync(id.Value);

            return View(workGenre);
        }

        // GET: WorkGenres/Create
        /// <summary>
        /// Work genre creation view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["GenreId"] = new SelectList(await _bll.Genres.GetAllAsync(), "Id", "Name");
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Title");
            return View();
        }

        // POST: WorkGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create work genre
        /// </summary>
        /// <param name="workGenre">Created work genre</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenreId,WorkId")] WorkGenre workGenre)
        {
            if (ModelState.IsValid)
            {
                workGenre.Id = Guid.NewGuid();
                _bll.WorkGenres.Add(workGenre);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(await _bll.Genres.GetAllAsync(), "Id", "Name", workGenre.GenreId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Title", workGenre.WorkId);
            return View(workGenre);
        }

        // GET: WorkGenres/Edit/5
        /// <summary>
        /// Work genre edit view
        /// </summary>
        /// <param name="id">Work genre ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workGenre = await _bll.WorkGenres.FirstOrDefaultAsync(id.Value);
            ViewData["GenreId"] = new SelectList(await _bll.Genres.GetAllAsync(), "Id", "Name", workGenre!.GenreId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Title", workGenre.WorkId);
            return View(workGenre);
        }

        // POST: WorkGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit work genre
        /// </summary>
        /// <param name="id">Work genre ID</param>
        /// <param name="workGenre">Updated work genre</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,GenreId,WorkId")] WorkGenre workGenre)
        {
            if (id != workGenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.WorkGenres.Update(workGenre);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WorkGenreExists(workGenre.Id))
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
            ViewData["GenreId"] = new SelectList(await _bll.Genres.GetAllAsync(), "Id", "Name", workGenre.GenreId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Title", workGenre.WorkId);
            return View(workGenre);
        }

        // GET: WorkGenres/Delete/5
        /// <summary>
        /// Work genre deletion view
        /// </summary>
        /// <param name="id">Work genre ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workGenre = await _bll.WorkGenres.FirstOrDefaultAsync(id.Value);

            return View(workGenre);
        }

        // POST: WorkGenres/Delete/5
        /// <summary>
        /// Delete work genre
        /// </summary>
        /// <param name="id">Work genre ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var workGenre = await _bll.WorkGenres.FirstOrDefaultAsync(id);
            _bll.WorkGenres.Remove(workGenre!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WorkGenreExists(Guid id)
        {
            return await _bll.WorkGenres.ExistsAsync(id);
        }
    }
}
