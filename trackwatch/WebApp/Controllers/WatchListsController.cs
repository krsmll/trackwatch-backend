using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Extensions.Base;
using WatchList = BLL.App.DTO.WatchList;

namespace WebApp.Controllers
{
    /// <summary>
    /// WatchListsController
    /// </summary>
    public class WatchListsController : Controller
    {
        
        private readonly IAppBLL _bll;

        /// <summary>
        /// WatchListsController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public WatchListsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WatchLists
        /// <summary>
        /// Watch list index view. List all watch lists.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.WatchLists.GetAllAsync(User.GetUserId() ?? default));
        }

        // GET: WatchLists/Details/5
        /// <summary>
        /// Detailed view of watch list
        /// </summary>
        /// <param name="id">Watch list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchList = await _bll.WatchLists.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);

            return View(watchList);
        }

        // GET: WatchLists/Create
        /// <summary>
        /// Watch list creation view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["RatingScaleId"] = new SelectList(await _bll.RatingScales.GetAllAsync(), "Id", "Id");
            return View();
        }

        // POST: WatchLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create watch list
        /// </summary>
        /// <param name="watchList">Created watch list</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RatingScaleId")] WatchList watchList)
        {
            if (ModelState.IsValid)
            {
                watchList.Id = Guid.NewGuid();
                watchList.AppUserId = User.GetUserId()!.Value;
                _bll.WatchLists.Add(watchList);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RatingScaleId"] = new SelectList(await _bll.RatingScales.GetAllAsync(), "Id", "Id", watchList.RatingScaleId);
            return View(watchList);
        }

        // GET: WatchLists/Edit/5
        /// <summary>
        /// Watch list edit view
        /// </summary>
        /// <param name="id">Watch list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchList = await _bll.WatchLists.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            ViewData["RatingScaleId"] = new SelectList(await _bll.RatingScales.GetAllAsync(), "Id", "Id", watchList!.RatingScaleId);
            return View(watchList);
        }

        // POST: WatchLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit watch list
        /// </summary>
        /// <param name="id">Watch list ID</param>
        /// <param name="watchList">Updated watch list</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RatingScaleId")] WatchList watchList)
        {
            if (id != watchList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.WatchLists.Update(watchList);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WatchListExists(watchList.Id))
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
            ViewData["RatingScaleId"] = new SelectList(await _bll.RatingScales.GetAllAsync(), "Id", "Id", watchList.RatingScaleId);
            return View(watchList);
        }

        // GET: WatchLists/Delete/5
        /// <summary>
        /// Watch list deletion view
        /// </summary>
        /// <param name="id">Watch list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchList = await _bll.WatchLists.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);

            return View(watchList);
        }

        // POST: WatchLists/Delete/5
        /// <summary>
        /// Delete watch list
        /// </summary>
        /// <param name="id">Watch list ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var watchList = await _bll.WatchLists.FirstOrDefaultAsync(id, User.GetUserId()!.Value);
            _bll.WatchLists.Remove(watchList!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WatchListExists(Guid id)
        {
            return await _bll.WatchLists.ExistsAsync(id);
        }
    }
}
