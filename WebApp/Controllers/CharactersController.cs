using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLL.App.DTO;

namespace WebApp.Controllers
{
    /// <summary>
    /// CharactersController
    /// </summary>
    public class CharactersController : Controller
    {

        private readonly IAppBLL _bll;

        /// <summary>
        /// CharactersController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public CharactersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Characters
        /// <summary>
        /// List of all characters
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Characters.GetAllAsync(noTracking: false));
        }

        // GET: Characters/Details/5
        /// <summary>
        /// Details of specific character
        /// </summary>
        /// <param name="id">Character ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _bll.Characters.FirstOrDefaultAsync(id.Value);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        /// <summary>
        /// Redirect to create character page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create character.
        /// </summary>
        /// <param name="character">Character to create</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Description,Age,Birthdate")] Character character)
        {
            if (ModelState.IsValid)
            {
                character.Id = Guid.NewGuid();
                _bll.Characters.Add(character);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        /// <summary>
        /// Redirect to edit character page
        /// </summary>
        /// <param name="id">Character ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _bll.Characters.FirstOrDefaultAsync(id.Value);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit character
        /// </summary>
        /// <param name="id">Character ID</param>
        /// <param name="character">Updated character</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Description,Age,Birthdate")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Characters.Update(character);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CharacterExists(character.Id))
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
            return View(character);
        }

        // GET: Characters/Delete/5
        /// <summary>
        /// Redirect to delete character page
        /// </summary>
        /// <param name="id">Character ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _bll.Characters.FirstOrDefaultAsync(id.Value);

            return View(character);
        }

        // POST: Characters/Delete/5
        /// <summary>
        /// Delete character
        /// </summary>
        /// <param name="id">Character ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var character = await _bll.Characters.FirstOrDefaultAsync(id);
            _bll.Characters.Remove(character!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CharacterExists(Guid id)
        {
            return await _bll.Characters.ExistsAsync(id);
        }
    }
}
