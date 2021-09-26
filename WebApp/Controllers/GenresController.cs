using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Genre = BLL.App.DTO.Genre;

namespace WebApp.Controllers
{
    /// <summary>
    /// GenresController
    /// </summary>
    public class GenresController : Controller
    {

        private readonly IAppBLL _bll;

        /// <summary>
        /// GenresController constructor
        /// </summary>
        /// <param name="bll"></param>
        public GenresController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Genres
        /// <summary>
        /// Genre index view. List all genres.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Genres.GetAllAsync());
        }

        // GET: Genres/Details/5
        /// <summary>
        /// Detailed genre view
        /// </summary>
        /// <param name="id">Genre ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _bll.Genres.FirstOrDefaultAsync(id.Value);

            return View(genre);
        }

        // GET: Genres/Create
        /// <summary>
        /// Genre create view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create genre
        /// </summary>
        /// <param name="genre">Genre ID</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                genre.Id = Guid.NewGuid();
                _bll.Genres.Add(genre);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        /// <summary>
        /// Genre edit view
        /// </summary>
        /// <param name="id">Genre ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _bll.Genres.FirstOrDefaultAsync(id.Value);
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit genre
        /// </summary>
        /// <param name="id">Genre ID</param>
        /// <param name="genre">Updated genre</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Genres.Update(genre);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await GenreExists(genre.Id))
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
            return View(genre);
        }

        // GET: Genres/Delete/5
        /// <summary>
        /// Genre deletion view
        /// </summary>
        /// <param name="id">Genre ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _bll.Genres.FirstOrDefaultAsync(id.Value);

            return View(genre);
        }

        // POST: Genres/Delete/5
        /// <summary>
        /// Delete genre
        /// </summary>
        /// <param name="id">Genre ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var genre = await _bll.Genres.FirstOrDefaultAsync(id);
            _bll.Genres.Remove(genre!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> GenreExists(Guid id)
        {
            return await _bll.Genres.ExistsAsync(id);
        }
    }
}
