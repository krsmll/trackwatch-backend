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
    /// Character persons controller
    /// </summary>
    public class CharacterPersonsController : Controller
    {
        private readonly AppDbContext _context;

        /// Character persons controller constructor
        public CharacterPersonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CharacterPersons
        /// <summary>
        /// Index view of character persons
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CharacterPersons.Include(c => c.Character).Include(c => c.WorkAuthor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CharacterPersons/Details/5
        /// <summary>
        /// Detailed view of a character person
        /// </summary>
        /// <param name="id">Character person ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterPerson = await _context.CharacterPersons
                .Include(c => c.Character)
                .Include(c => c.WorkAuthor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterPerson == null)
            {
                return NotFound();
            }

            return View(characterPerson);
        }

        // GET: CharacterPersons/Create
        /// <summary>
        /// Create character person view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "FirstName");
            ViewData["WorkAuthorId"] = new SelectList(_context.WorkAuthors, "Id", "Id");
            return View();
        }

        // POST: CharacterPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creation of a character person
        /// </summary>
        /// <param name="characterPerson">Character person to add to the system</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterId,WorkAuthorId,Id")] CharacterPerson characterPerson)
        {
            if (ModelState.IsValid)
            {
                characterPerson.Id = Guid.NewGuid();
                _context.Add(characterPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "FirstName", characterPerson.CharacterId);
            ViewData["WorkAuthorId"] = new SelectList(_context.WorkAuthors, "Id", "Id", characterPerson.WorkAuthorId);
            return View(characterPerson);
        }

        // GET: CharacterPersons/Edit/5
        /// <summary>
        /// Edit character person view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterPerson = await _context.CharacterPersons.FindAsync(id);
            if (characterPerson == null)
            {
                return NotFound();
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "FirstName", characterPerson.CharacterId);
            ViewData["WorkAuthorId"] = new SelectList(_context.WorkAuthors, "Id", "Id", characterPerson.WorkAuthorId);
            return View(characterPerson);
        }

        // POST: CharacterPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit character person
        /// </summary>
        /// <param name="id">Character person ID</param>
        /// <param name="characterPerson">Edited character person</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CharacterId,WorkAuthorId,Id")] CharacterPerson characterPerson)
        {
            if (id != characterPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterPersonExists(characterPerson.Id))
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
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "FirstName", characterPerson.CharacterId);
            ViewData["WorkAuthorId"] = new SelectList(_context.WorkAuthors, "Id", "Id", characterPerson.WorkAuthorId);
            return View(characterPerson);
        }

        // GET: CharacterPersons/Delete/5
        /// <summary>
        /// Delete character person view
        /// </summary>
        /// <param name="id">Character person ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterPerson = await _context.CharacterPersons
                .Include(c => c.Character)
                .Include(c => c.WorkAuthor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterPerson == null)
            {
                return NotFound();
            }

            return View(characterPerson);
        }

        // POST: CharacterPersons/Delete/5
        /// <summary>
        /// Deletion of a character person
        /// </summary>
        /// <param name="id">Character person ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var characterPerson = await _context.CharacterPersons.FindAsync(id);
            _context.CharacterPersons.Remove(characterPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterPersonExists(Guid id)
        {
            return _context.CharacterPersons.Any(e => e.Id == id);
        }
    }
}
