using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Status = BLL.App.DTO.Status;

namespace WebApp.Controllers
{
    /// <summary>
    /// StatusesController
    /// </summary>
    public class StatusesController : Controller
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// StatusesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public StatusesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Statuses
        /// <summary>
        /// Status index view. List all statuses.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Statuses.GetAllAsync());
        }

        // GET: Statuses/Details/5
        /// <summary>
        /// Detailed status view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _bll.Statuses.FirstOrDefaultAsync(id.Value);

            return View(status);
        }

        // GET: Statuses/Create
        /// <summary>
        /// Status creation view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statuses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create status
        /// </summary>
        /// <param name="status">Created status</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Status status)
        {
            if (ModelState.IsValid)
            {
                status.Id = Guid.NewGuid();
                _bll.Statuses.Add(status);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: Statuses/Edit/5
        /// <summary>
        /// Status edit view
        /// </summary>
        /// <param name="id">Status ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _bll.Statuses.FirstOrDefaultAsync(id.Value);
            return View(status);
        }

        // POST: Statuses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit status
        /// </summary>
        /// <param name="id">Status ID</param>
        /// <param name="status">Updated status</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] Status status)
        {
            if (id != status.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Statuses.Update(status);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StatusExists(status.Id))
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
            return View(status);
        }

        // GET: Statuses/Delete/5
        /// <summary>
        /// Status deletion view
        /// </summary>
        /// <param name="id">Status ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _bll.Statuses.FirstOrDefaultAsync(id.Value);

            return View(status);
        }

        // POST: Statuses/Delete/5
        /// <summary>
        /// Delete status
        /// </summary>
        /// <param name="id">Status ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var status = await _bll.Statuses.FirstOrDefaultAsync(id);
            _bll.Statuses.Remove(status!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StatusExists(Guid id)
        {
            return await _bll.Statuses.ExistsAsync(id);
        }
    }
}
