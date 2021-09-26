using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLL.App.DTO;

namespace WebApp.Controllers
{
    /// <summary>
    /// CharacterInListsController
    /// </summary>
    public class CharacterInListsController : Controller
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// CharacterInListsController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public CharacterInListsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: CharacterInLists
        /// <summary>
        /// Lists all characters in lists
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.CharacterInLists.GetAllAsync());
        }

        // GET: CharacterInLists/Details/5
        /// <summary>
        /// Details on specific character in list
        /// </summary>
        /// <param name="id">Character in list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterInList = await _bll.CharacterInLists
                .FirstOrDefaultAsync(id.Value);

            return View(characterInList);
        }

        // GET: CharacterInLists/Create
        /// <summary>
        /// Redirects to character in list creation page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName");
            ViewData["FavCharacterListId"] = new SelectList(await _bll.FavCharacterLists.GetAllAsync(), "Id", "Id");
            return View();
        }

        // POST: CharacterInLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates a character in list.
        /// </summary>
        /// <param name="characterInList">Character in list to add</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CharacterId,FavCharacterListId")] CharacterInList characterInList)
        {
            if (ModelState.IsValid)
            {
                characterInList.Id = Guid.NewGuid();
                _bll.CharacterInLists.Add(characterInList);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName", characterInList.CharacterId);
            ViewData["FavCharacterListId"] = new SelectList(await _bll.FavCharacterLists.GetAllAsync(), "Id", "Id", characterInList.FavCharacterListId);
            return View(characterInList);
        }

        // GET: CharacterInLists/Edit/5
        /// <summary>
        /// Redirects to character in list edit page
        /// </summary>
        /// <param name="id">Character in list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterInList = await _bll.CharacterInLists.FirstOrDefaultAsync(id.Value);

            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName", characterInList!.CharacterId);
            ViewData["FavCharacterListId"] = new SelectList(await _bll.FavCharacterLists.GetAllAsync(), "Id", "Id", characterInList.FavCharacterListId);
            return View(characterInList);
        }

        // POST: CharacterInLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the character in list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterInList"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CharacterId,FavCharacterListId")] CharacterInList characterInList)
        {
            if (id != characterInList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.CharacterInLists.Update(characterInList);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CharacterInListExists(characterInList.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName", characterInList.CharacterId);
            ViewData["FavCharacterListId"] = new SelectList(await _bll.FavCharacterLists.GetAllAsync(), "Id", "Id", characterInList.FavCharacterListId);
            return View(characterInList);
        }

        // GET: CharacterInLists/Delete/5
        /// <summary>
        /// Redirects to character in list page
        /// </summary>
        /// <param name="id">Character in list ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterInList = await _bll.CharacterInLists.FirstOrDefaultAsync(id.Value);

            return View(characterInList);
        }

        // POST: CharacterInLists/Delete/5
        /// <summary>
        /// Deletes the character in list
        /// </summary>
        /// <param name="id">Character in list ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var characterInList = await _bll.CharacterInLists.FirstOrDefaultAsync(id);
            _bll.CharacterInLists.Remove(characterInList!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CharacterInListExists(Guid id)
        {
            return await _bll.CharacterInLists.ExistsAsync(id);
        }
    }
}
