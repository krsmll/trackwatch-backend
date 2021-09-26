using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Extensions.Base;
using FavCharacterList = BLL.App.DTO.FavCharacterList;

namespace WebApp.Controllers
{
    /// <summary>
    /// FavCharacterListsController
    /// </summary>
    public class FavCharacterListsController : Controller
    {

        private readonly IAppBLL _bll;
        
        /// <summary>
        /// FavCharacterListsController constructor
        /// </summary>
        /// <param name="bll"></param>
        public FavCharacterListsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: FavCharacterLists
        /// <summary>
        /// List all favorite character lists
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.FavCharacterLists.GetAllAsync(User.GetUserId() ?? default));
        }

        // GET: FavCharacterLists/Details/5
        /// <summary>
        /// Detailed view of favorite character list
        /// </summary>
        /// <param name="id">Favorite character list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favCharacterList = await _bll.FavCharacterLists.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value!);

            return View(favCharacterList);
        }

        // GET: FavCharacterLists/Create
        /// <summary>
        /// Redirect to favorite character list creation page
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavCharacterLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create favorite character list
        /// </summary>
        /// <param name="favCharacterList">Created favorite character list</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] FavCharacterList favCharacterList)
        {
            if (ModelState.IsValid)
            {
                favCharacterList.Id = Guid.NewGuid();
                favCharacterList.AppUserId = User.GetUserId()!.Value!;
                _bll.FavCharacterLists.Add(favCharacterList);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favCharacterList);
        }

        // GET: FavCharacterLists/Edit/5
        /// <summary>
        /// Redirect to favorite character list edit page
        /// </summary>
        /// <param name="id">Favorite character list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favCharacterList = await _bll.FavCharacterLists.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value!);
            return View(favCharacterList);
        }

        // POST: FavCharacterLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Update favorite character list
        /// </summary>
        /// <param name="id">Favorite character list ID</param>
        /// <param name="favCharacterList">Updated favorite character list</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] FavCharacterList favCharacterList)
        {
            if (id != favCharacterList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.FavCharacterLists.Update(favCharacterList);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FavCharacterListExists(favCharacterList.Id))
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
            return View(favCharacterList);
        }

        // GET: FavCharacterLists/Delete/5
        /// <summary>
        /// Redirect to favorite character list deletion page
        /// </summary>
        /// <param name="id">Favorite character list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favCharacterList = await _bll.FavCharacterLists.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value!);

            return View(favCharacterList);
        }

        // POST: FavCharacterLists/Delete/5
        /// <summary>
        /// Delete favorite character list
        /// </summary>
        /// <param name="id">Favorite character list ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var favCharacterList = await _bll.FavCharacterLists.FirstOrDefaultAsync(id, User.GetUserId()!.Value!);
            _bll.FavCharacterLists.Remove(favCharacterList!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FavCharacterListExists(Guid id)
        {
            return await _bll.FavCharacterLists.ExistsAsync(id);
        }
    }
}
