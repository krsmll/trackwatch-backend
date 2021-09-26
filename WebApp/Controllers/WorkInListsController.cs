using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkInList = BLL.App.DTO.WorkInList;

namespace WebApp.Controllers
{
    /// <summary>
    /// WorkInListsController
    /// </summary>
    public class WorkInListsController : Controller
    {
        
        private readonly IAppBLL _bll;

        /// <summary>
        /// WorkInListsController constructor
        /// </summary>
        /// <param name="bll"></param>
        public WorkInListsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkInLists
        /// <summary>
        /// Work in list index view. List all work in lists.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.WorkInLists.GetAllAsync());
        }

        // GET: WorkInLists/Details/5
        /// <summary>
        /// Detailed view of work in list
        /// </summary>
        /// <param name="id">Work in list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workInList = await _bll.WorkInLists.FirstOrDefaultAsync(id.Value);

            return View(workInList);
        }

        // GET: WorkInLists/Create
        /// <summary>
        /// Work in list creation view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["StatusId"] = new SelectList(await _bll.Statuses.GetAllAsync(), "Id", "Name");
            ViewData["WatchListId"] = new SelectList(await _bll.WatchLists.GetAllAsync(), "Id", "Id");
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: WorkInLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create work in list
        /// </summary>
        /// <param name="workInList">Created work in list</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WatchListId,WorkId,StatusId,Started,Finished,Notes,Rating")] WorkInList workInList)
        {
            if (ModelState.IsValid)
            {
                workInList.Id = Guid.NewGuid();
                _bll.WorkInLists.Add(workInList);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(await _bll.Statuses.GetAllAsync(), "Id", "Name", workInList.StatusId);
            ViewData["WatchListId"] = new SelectList(await _bll.WatchLists.GetAllAsync(), "Id", "Id", workInList.WatchListId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", workInList.WorkId);
            return View(workInList);
        }

        // GET: WorkInLists/Edit/5
        /// <summary>
        /// Work in list edit page
        /// </summary>
        /// <param name="id">Work in list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workInList = await _bll.WorkInLists.FirstOrDefaultAsync(id.Value);
            ViewData["StatusId"] = new SelectList(await _bll.Statuses.GetAllAsync(), "Id", "Name", workInList!.StatusId);
            ViewData["WatchListId"] = new SelectList(await _bll.WatchLists.GetAllAsync(), "Id", "Id", workInList.WatchListId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", workInList.WorkId);
            return View(workInList);
        }

        // POST: WorkInLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit work in list
        /// </summary>
        /// <param name="id">Work in list ID</param>
        /// <param name="workInList">Updated work in list</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,WatchListId,WorkId,StatusId,Started,Finished,Notes,Rating")] WorkInList workInList)
        {
            if (id != workInList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.WorkInLists.Update(workInList);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WorkInListExists(workInList.Id))
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
            ViewData["StatusId"] = new SelectList(await _bll.Statuses.GetAllAsync(), "Id", "Name", workInList.StatusId);
            ViewData["WatchListId"] = new SelectList(await _bll.WatchLists.GetAllAsync(), "Id", "Id", workInList.WatchListId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", workInList.WorkId);
            return View(workInList);
        }

        // GET: WorkInLists/Delete/5
        /// <summary>
        /// Work in list deletion view
        /// </summary>
        /// <param name="id">Work in list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workInList = await _bll.WorkInLists.FirstOrDefaultAsync(id.Value);

            return View(workInList);
        }

        // POST: WorkInLists/Delete/5
        /// <summary>
        /// Delete work in list
        /// </summary>
        /// <param name="id">Work in list ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var workInList = await _bll.WorkInLists.FirstOrDefaultAsync(id);
            _bll.WorkInLists.Remove(workInList!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WorkInListExists(Guid id)
        {
            return await _bll.WorkInLists.ExistsAsync(id);
        }
    }
}
