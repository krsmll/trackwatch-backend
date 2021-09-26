using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;

namespace WebApp.Controllers
{
    /// <summary>
    /// Work relations controller
    /// </summary>
    public class WorkRelationsController : Controller
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Work relations controller constructor
        /// </summary>
        /// <param name="context"></param>
        public WorkRelationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkRelations
        /// <summary>
        /// Index view of work relations
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WorkRelations.Include(w => w.RelatedWork).Include(w => w.Work);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WorkRelations/Details/5
        /// <summary>
        /// Detailed view of work relation
        /// </summary>
        /// <param name="id">Work relation ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workRelation = await _context.WorkRelations
                .Include(w => w.RelatedWork)
                .Include(w => w.Work)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workRelation == null)
            {
                return NotFound();
            }

            return View(workRelation);
        }

        // GET: WorkRelations/Create
        /// <summary>
        /// Creation view of work relation
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["RelatedWorkId"] = new SelectList(_context.Works, "Id", "Title");
            ViewData["WorkId"] = new SelectList(_context.Works, "Id", "Title");
            return View();
        }

        // POST: WorkRelations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creation of work relation 
        /// </summary>
        /// <param name="workRelation">Work relation to add to the system</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkId,RelatedWorkId,Id")] WorkRelation workRelation)
        {
            if (ModelState.IsValid)
            {
                workRelation.Id = Guid.NewGuid();
                _context.Add(workRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RelatedWorkId"] = new SelectList(_context.Works, "Id", "Title", workRelation.RelatedWorkId);
            ViewData["WorkId"] = new SelectList(_context.Works, "Id", "Title", workRelation.WorkId);
            return View(workRelation);
        }

        // GET: WorkRelations/Edit/5
        /// <summary>
        /// Edit view of work relation
        /// </summary>
        /// <param name="id">Work relation ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workRelation = await _context.WorkRelations.FindAsync(id);
            if (workRelation == null)
            {
                return NotFound();
            }
            ViewData["RelatedWorkId"] = new SelectList(_context.Works, "Id", "Title", workRelation.RelatedWorkId);
            ViewData["WorkId"] = new SelectList(_context.Works, "Id", "Title", workRelation.WorkId);
            return View(workRelation);
        }

        // POST: WorkRelations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Editing of work relation
        /// </summary>
        /// <param name="id">Work relation ID</param>
        /// <param name="workRelation">Edited work relation</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("WorkId,RelatedWorkId,Id")] WorkRelation workRelation)
        {
            if (id != workRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkRelationExists(workRelation.Id))
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
            ViewData["RelatedWorkId"] = new SelectList(_context.Works, "Id", "Title", workRelation.RelatedWorkId);
            ViewData["WorkId"] = new SelectList(_context.Works, "Id", "Title", workRelation.WorkId);
            return View(workRelation);
        }

        // GET: WorkRelations/Delete/5
        /// <summary>
        /// Delete view of work relation
        /// </summary>
        /// <param name="id">Work relation ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workRelation = await _context.WorkRelations
                .Include(w => w.RelatedWork)
                .Include(w => w.Work)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workRelation == null)
            {
                return NotFound();
            }

            return View(workRelation);
        }

        // POST: WorkRelations/Delete/5
        /// <summary>
        /// Deletion of work relation
        /// </summary>
        /// <param name="id">Work relation ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var workRelation = await _context.WorkRelations.FindAsync(id);
            _context.WorkRelations.Remove(workRelation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkRelationExists(Guid id)
        {
            return _context.WorkRelations.Any(e => e.Id == id);
        }
    }
}
