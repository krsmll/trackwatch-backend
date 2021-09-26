using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CharacterPicture = BLL.App.DTO.CharacterPicture;

namespace WebApp.Controllers
{
    /// <summary>
    /// CharacterPicturesController
    /// </summary>
    public class CharacterPicturesController : Controller
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// CharacterPicturesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public CharacterPicturesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: CharacterPictures
        /// <summary>
        /// Lists all character pictures
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.CharacterPictures.GetAllAsync());
        }

        // GET: CharacterPictures/Details/5
        /// <summary>
        /// Shows details about a character picture
        /// </summary>
        /// <param name="id">Character picture ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterPicture = await _bll.CharacterPictures.FirstOrDefaultAsync(id.Value);

            return View(characterPicture);
        }

        // GET: CharacterPictures/Create
        /// <summary>
        /// Redirects user to character picture create page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName");
            return View();
        }

        // POST: CharacterPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates character picture
        /// </summary>
        /// <param name="characterPicture">Character picture</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CharacterId,URL")] CharacterPicture characterPicture)
        {
            if (ModelState.IsValid)
            {
                characterPicture.Id = Guid.NewGuid();
                _bll.CharacterPictures.Add(characterPicture);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName", characterPicture.CharacterId);
            return View(characterPicture);
        }

        // GET: CharacterPictures/Edit/5
        /// <summary>
        /// Redirects user to character picture edit page
        /// </summary>
        /// <param name="id">Character picture ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterPicture = await _bll.CharacterPictures.FirstOrDefaultAsync(id.Value);
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName", characterPicture!.CharacterId);
            return View(characterPicture);
        }

        // POST: CharacterPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits character picture
        /// </summary>
        /// <param name="id">Character picture ID</param>
        /// <param name="characterPicture">Updated character picture</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CharacterId,URL")] CharacterPicture characterPicture)
        {
            if (id != characterPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.CharacterPictures.Update(characterPicture);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CharacterPictureExists(characterPicture.Id))
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
            ViewData["CharacterId"] = new SelectList(await _bll.Characters.GetAllAsync(), "Id", "FirstName", characterPicture.CharacterId);
            return View(characterPicture);
        }

        // GET: CharacterPictures/Delete/5
        /// <summary>
        /// Redirect user to delete page
        /// </summary>
        /// <param name="id">Character picture ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterPicture = await _bll.CharacterPictures.FirstOrDefaultAsync(id.Value);

            return View(characterPicture);
        }

        // POST: CharacterPictures/Delete/5
        /// <summary>
        /// Delete character picture
        /// </summary>
        /// <param name="id">Character picture ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var characterPicture = await _bll.CharacterPictures.FirstOrDefaultAsync(id);
            _bll.CharacterPictures.Remove(characterPicture!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CharacterPictureExists(Guid id)
        {
            return await _bll.CharacterPictures.ExistsAsync(id);
        }
    }
}
