using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkAuthor = BLL.App.DTO.WorkAuthor;

namespace WebApp.Controllers
{
    /// <summary>
    /// WorkAuthorsController
    /// </summary>
    public class WorkAuthorsController : Controller
    {
        
        private readonly IAppBLL _bll;

        /// <summary>
        /// WorkAuthorsController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public WorkAuthorsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkAuthors
        /// <summary>
        /// Work author index view. List all work authors.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            
            return View(await _bll.WorkAuthors.GetAllAsync());
        }

        // GET: WorkAuthors/Details/5
        /// <summary>
        /// Detailed view of work author
        /// </summary>
        /// <param name="id">Work author ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workAuthor = await _bll.WorkAuthors.FirstOrDefaultAsync(id.Value);

            return View(workAuthor);
        }

        // GET: WorkAuthors/Create
        /// <summary>
        /// Work author creation view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["PersonId"] = new SelectList(await _bll.Persons.GetAllAsync(), "Id", "FirstName");
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: WorkAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create work author
        /// </summary>
        /// <param name="workAuthor">Created work author</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,WorkId")] WorkAuthor workAuthor)
        {
            if (ModelState.IsValid)
            {
                workAuthor.Id = Guid.NewGuid();
                _bll.WorkAuthors.Add(workAuthor);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(await _bll.Persons.GetAllAsync(), "Id", "FirstName", workAuthor.PersonId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", workAuthor.WorkId);
            return View(workAuthor);
        }

        // GET: WorkAuthors/Edit/5
        /// <summary>
        /// Work author edit view
        /// </summary>
        /// <param name="id">Work author ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workAuthor = await _bll.WorkAuthors.FirstOrDefaultAsync(id.Value);
            ViewData["PersonId"] = new SelectList(await _bll.Persons.GetAllAsync(), "Id", "FirstName", workAuthor!.PersonId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", workAuthor.WorkId);
            return View(workAuthor);
        }

        // POST: WorkAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit work author
        /// </summary>
        /// <param name="id">Work author ID</param>
        /// <param name="workAuthor">Updated work author</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PersonId,WorkId")] WorkAuthor workAuthor)
        {
            if (id != workAuthor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.WorkAuthors.Update(workAuthor);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WorkAuthorExists(workAuthor.Id))
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
            ViewData["PersonId"] = new SelectList(await _bll.Persons.GetAllAsync(), "Id", "FirstName", workAuthor.PersonId);
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", workAuthor.WorkId);
            return View(workAuthor);
        }

        // GET: WorkAuthors/Delete/5
        /// <summary>
        /// Work author deletion view
        /// </summary>
        /// <param name="id">Work author ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workAuthor = await _bll.WorkAuthors.FirstOrDefaultAsync(id.Value);

            return View(workAuthor);
        }

        // POST: WorkAuthors/Delete/5
        /// <summary>
        /// Delete work author
        /// </summary>
        /// <param name="id">Work author ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var workAuthor = await _bll.WorkAuthors.FirstOrDefaultAsync(id);
            _bll.WorkAuthors.Remove(workAuthor!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WorkAuthorExists(Guid id)
        {
            return await _bll.WorkAuthors.ExistsAsync(id);
        }
    }
}
