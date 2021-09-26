using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Format = BLL.App.DTO.Format;

namespace WebApp.Controllers
{
    /// <summary>
    /// FormatsController
    /// </summary>
    public class FormatsController : Controller
    {

        private readonly IAppBLL _bll;

        /// <summary>
        /// FormatsController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public FormatsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Formats
        /// <summary>
        /// List all formats
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Formats.GetAllAsync());
        }

        // GET: Formats/Details/5
        /// <summary>
        /// Detailed view of format
        /// </summary>
        /// <param name="id">Format ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var format = await _bll.Formats.FirstOrDefaultAsync(id.Value);

            return View(format);
        }

        // GET: Formats/Create
        /// <summary>
        /// Format creation view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create format
        /// </summary>
        /// <param name="format">Created format</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Format format)
        {
            if (ModelState.IsValid)
            {
                format.Id = Guid.NewGuid();
                _bll.Formats.Add(format);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(format);
        }

        // GET: Formats/Edit/5
        /// <summary>
        /// Format edit view
        /// </summary>
        /// <param name="id">Format ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var format = await _bll.Formats.FirstOrDefaultAsync(id.Value);
            return View(format);
        }

        // POST: Formats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit format
        /// </summary>
        /// <param name="id">Format ID</param>
        /// <param name="format">Updated format</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Format format)
        {
            if (id != format.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Formats.Update(format);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FormatExists(format.Id))
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
            return View(format);
        }

        // GET: Formats/Delete/5
        /// <summary>
        /// Format delete view
        /// </summary>
        /// <param name="id">Format ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var format = await _bll.Formats.FirstOrDefaultAsync(id.Value);

            return View(format);
        }

        // POST: Formats/Delete/5
        /// <summary>
        /// Delete format
        /// </summary>
        /// <param name="id">Format ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var format = await _bll.Formats.FirstOrDefaultAsync(id);
            _bll.Formats.Remove(format!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FormatExists(Guid id)
        {
            return await _bll.Formats.ExistsAsync(id);
        }
    }
}
