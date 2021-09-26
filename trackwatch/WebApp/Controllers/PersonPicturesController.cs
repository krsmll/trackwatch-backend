using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonPicture = BLL.App.DTO.PersonPicture;

namespace WebApp.Controllers
{
    /// <summary>
    /// PersonPicturesController
    /// </summary>
    public class PersonPicturesController : Controller
    {

        private readonly IAppBLL _bll;
        
        /// <summary>
        /// PersonPicturesController constructor
        /// </summary>
        /// <param name="bll"></param>
        public PersonPicturesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: PersonPictures
        /// <summary>
        /// Person picture index view. List all person pictures.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.PersonPictures.GetAllAsync());
        }

        // GET: PersonPictures/Details/5
        /// <summary>
        /// Detailed person picture view
        /// </summary>
        /// <param name="id">Person picture ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPicture = await _bll.PersonPictures.FirstOrDefaultAsync(id.Value);

            return View(personPicture);
        }

        // GET: PersonPictures/Create
        /// <summary>
        /// Person picture create view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["PersonId"] = new SelectList(await _bll.Persons.GetAllAsync(), "Id", "FirstName");
            return View();
        }

        // POST: PersonPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create person picture
        /// </summary>
        /// <param name="personPicture">Created person picture</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,URL")] PersonPicture personPicture)
        {
            if (ModelState.IsValid)
            {
                personPicture.Id = Guid.NewGuid();
                _bll.PersonPictures.Add(personPicture);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(await _bll.Persons.GetAllAsync(), "Id", "FirstName", personPicture.PersonId);
            return View(personPicture);
        }

        // GET: PersonPictures/Edit/5
        /// <summary>
        /// Person picture edit view
        /// </summary>
        /// <param name="id">Person picture ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPicture = await _bll.PersonPictures.FirstOrDefaultAsync(id.Value);
            ViewData["PersonId"] = new SelectList(await _bll.Persons.GetAllAsync(), "Id", "FirstName", personPicture!.PersonId);
            return View(personPicture);
        }

        // POST: PersonPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit person picture
        /// </summary>
        /// <param name="id">Person picture ID</param>
        /// <param name="personPicture">Updated person picture</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PersonId,URL")] PersonPicture personPicture)
        {
            if (id != personPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.PersonPictures.Update(personPicture);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PersonPictureExists(personPicture.Id))
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
            ViewData["PersonId"] = new SelectList(await _bll.Persons.GetAllAsync(), "Id", "FirstName", personPicture.PersonId);
            return View(personPicture);
        }

        // GET: PersonPictures/Delete/5
        /// <summary>
        /// Person picture delete view
        /// </summary>
        /// <param name="id">Person picture ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPicture = await _bll.PersonPictures.FirstOrDefaultAsync(id.Value);

            return View(personPicture);
        }

        // POST: PersonPictures/Delete/5
        /// <summary>
        /// Delete person picture
        /// </summary>
        /// <param name="id">Person picture ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var personPicture = await _bll.PersonPictures.FirstOrDefaultAsync(id);
            _bll.PersonPictures.Remove(personPicture!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonPictureExists(Guid id)
        {
            return await _bll.PersonPictures.ExistsAsync(id);
        }
    }
}
