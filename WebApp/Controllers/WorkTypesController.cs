using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkType = BLL.App.DTO.WorkType;

namespace WebApp.Controllers
{
    /// <summary>
    /// WorkTypesController
    /// </summary>
    public class WorkTypesController : Controller
    {
        
        private readonly IAppBLL _bll;

        /// <summary>
        /// WorkTypesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public WorkTypesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkTypes
        /// <summary>
        /// Work types index view. List all work types.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.WorkTypes.GetAllAsync());
        }

        // GET: WorkTypes/Details/5
        /// <summary>
        /// Detailed view of work type
        /// </summary>
        /// <param name="id">Work type ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workType = await _bll.WorkTypes
                .FirstOrDefaultAsync(id.Value);

            return View(workType);
        }

        // GET: WorkTypes/Create
        /// <summary>
        /// Work type creation view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create work type
        /// </summary>
        /// <param name="workType">Created work type</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] WorkType workType)
        {
            if (ModelState.IsValid)
            {
                workType.Id = Guid.NewGuid();
                _bll.WorkTypes.Add(workType);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workType);
        }

        // GET: WorkTypes/Edit/5
        /// <summary>
        /// Work type edit view
        /// </summary>
        /// <param name="id">Work type ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workType = await _bll.WorkTypes.FirstOrDefaultAsync(id.Value);
            return View(workType);
        }

        // POST: WorkTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit work type
        /// </summary>
        /// <param name="id">Work type ID</param>
        /// <param name="workType">Updated work type</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] WorkType workType)
        {
            if (id != workType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.WorkTypes.Update(workType);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WorkTypeExists(workType.Id))
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
            return View(workType);
        }

        // GET: WorkTypes/Delete/5
        /// <summary>
        /// Work type deletion view
        /// </summary>
        /// <param name="id">Work type ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workType = await _bll.WorkTypes
                .FirstOrDefaultAsync(id.Value);

            return View(workType);
        }

        // POST: WorkTypes/Delete/5
        /// <summary>
        /// Delete work type
        /// </summary>
        /// <param name="id">Work type ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var workType = await _bll.WorkTypes.FirstOrDefaultAsync(id);
            _bll.WorkTypes.Remove(workType!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WorkTypeExists(Guid id)
        {
            return await _bll.WorkTypes.ExistsAsync(id);
        }
    }
}
