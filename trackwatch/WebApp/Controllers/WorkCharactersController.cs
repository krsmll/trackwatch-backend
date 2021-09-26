using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkCharacter = BLL.App.DTO.WorkCharacter;

namespace WebApp.Controllers
{
    /// <summary>
    /// WorkCharactersController
    /// </summary>
    public class WorkCharactersController : Controller
    {
        
        private readonly IAppBLL _bll;

        /// <summary>
        /// WorkCharactersController constructor
        /// </summary>
        /// <param name="bll"></param>
        public WorkCharactersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkCharacters
        /// <summary>
        /// Work character index view. List all work characters.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.WorkCharacters.GetAllAsync());
        }

        // GET: WorkCharacters/Details/5
        /// <summary>
        /// Detailed view of work character.
        /// </summary>
        /// <param name="id">Work character ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workCharacter = await _bll.WorkCharacters.FirstOrDefaultAsync(id.Value);
            if (workCharacter == null)
            {
                return NotFound();
            }

            return View(workCharacter);
        }

        // GET: WorkCharacters/Create
        /// <summary>
        /// Work character creation view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName");
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: WorkCharacters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create work character
        /// </summary>
        /// <param name="workCharacter">Created work character</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkId,CharacterId")] WorkCharacter workCharacter)
        {
            if (ModelState.IsValid)
            {
                workCharacter.Id = Guid.NewGuid();
                _bll.WorkCharacters.Add(workCharacter);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName", workCharacter.CharacterId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", workCharacter.WorkId);
            return View(workCharacter);
        }

        // GET: WorkCharacters/Edit/5
        /// <summary>
        /// Work character edit view
        /// </summary>
        /// <param name="id">Work character ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workCharacter = await _bll.WorkCharacters.FirstOrDefaultAsync(id.Value);
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName", workCharacter!.CharacterId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", workCharacter.WorkId);
            return View(workCharacter);
        }

        // POST: WorkCharacters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit work character
        /// </summary>
        /// <param name="id">Work character ID</param>
        /// <param name="workCharacter">Updated work character</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,WorkId,CharacterId")] WorkCharacter workCharacter)
        {
            if (id != workCharacter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.WorkCharacters.Update(workCharacter);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WorkCharacterExists(workCharacter.Id))
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
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName", workCharacter.CharacterId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", workCharacter.WorkId);
            return View(workCharacter);
        }

        // GET: WorkCharacters/Delete/5
        /// <summary>
        /// Work character delete view
        /// </summary>
        /// <param name="id">Work character ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workCharacter = await _bll.WorkCharacters.FirstOrDefaultAsync(id.Value);

            return View(workCharacter);
        }

        // POST: WorkCharacters/Delete/5
        /// <summary>
        /// Delete work character
        /// </summary>
        /// <param name="id">Work character ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var workCharacter = await _bll.WorkCharacters.FirstOrDefaultAsync(id);
            _bll.WorkCharacters.Remove(workCharacter!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WorkCharacterExists(Guid id)
        {
            return await _bll.WorkCharacters.ExistsAsync(id);
        }
    }
}
