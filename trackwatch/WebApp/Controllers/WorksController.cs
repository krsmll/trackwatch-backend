using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Work = BLL.App.DTO.Work;

namespace WebApp.Controllers
{
    /// <summary>
    /// WorksController
    /// </summary>
    public class WorksController : Controller
    {
        private readonly IAppBLL _bll;
        
        /// <summary>
        /// WorksController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public WorksController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Works
        /// <summary>
        /// Work index page. List all works.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Works.GetAllAsync());
        }

        // GET: Works/Details/5
        /// <summary>
        /// Detailed view of work
        /// </summary>
        /// <param name="id">Work ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _bll.Works.FirstOrDefaultAsync(id.Value);

            return View(work);
        }

        // GET: Works/Create
        /// <summary>
        /// Work creation view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["FormatId"] = new SelectList(await _bll.Formats.GetAllAsync(), "Id", "Name");
            ViewData["WorkTypeId"] = new SelectList(await _bll.WorkTypes.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create work
        /// </summary>
        /// <param name="work">Work ID</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FormatId,WorkTypeId,Title,Description,ReleaseDate,FinishDate,EpisodeNumber")] Work work)
        {
            if (ModelState.IsValid)
            {
                work.Id = Guid.NewGuid();
                _bll.Works.Add(work);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormatId"] = new SelectList(await _bll.Formats.GetAllAsync(), "Id", "Name", work.FormatId);
            ViewData["WorkTypeId"] = new SelectList(await  _bll.WorkTypes.GetAllAsync(), "Id", "Name", work.WorkTypeId);
            return View(work);
        }

        // GET: Works/Edit/5
        /// <summary>
        /// Work edit view
        /// </summary>
        /// <param name="id">Work ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _bll.Works.FirstOrDefaultAsync(id.Value);
            ViewData["FormatId"] = new SelectList(await _bll.Formats.GetAllAsync(), "Id", "Name", work!.FormatId);
            ViewData["WorkTypeId"] = new SelectList(await  _bll.WorkTypes.GetAllAsync(), "Id", "Name", work.WorkTypeId);
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit work
        /// </summary>
        /// <param name="id">Work ID</param>
        /// <param name="work">Updated work</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FormatId,WorkTypeId,Title,Description,ReleaseDate,FinishDate,EpisodeNumber")] Work work)
        {
            if (id != work.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Works.Update(work);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WorkExists(work.Id))
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
            ViewData["FormatId"] = new SelectList(await _bll.Formats.GetAllAsync(), "Id", "Name", work.FormatId);
            ViewData["WorkTypeId"] = new SelectList(await  _bll.WorkTypes.GetAllAsync(), "Id", "Name", work.WorkTypeId);
            return View(work);
        }

        // GET: Works/Delete/5
        /// <summary>
        /// Work deletion view
        /// </summary>
        /// <param name="id">Work ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _bll.Works.FirstOrDefaultAsync(id.Value);

            return View(work);
        }

        // POST: Works/Delete/5
        /// <summary>
        /// Delete work
        /// </summary>
        /// <param name="id">Work ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var work = await _bll.Works.FirstOrDefaultNoIncludesAsync(id);
            _bll.Works.Remove(work!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WorkExists(Guid id)
        {
            return await _bll.Works.ExistsAsync(id);
        }
    }
}
