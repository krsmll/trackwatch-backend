using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain.App;
using Person = BLL.App.DTO.Person;

namespace WebApp.Controllers
{
    /// <summary>
    /// PersonsController
    /// </summary>
    public class PersonsController : Controller
    {
        
        private readonly IAppBLL _bll;

        /// <summary>
        /// PersonsController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public PersonsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Persons
        /// <summary>
        /// Person index view. List all persons.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Persons.GetAllAsync(noTracking: false));
        }

        // GET: Persons/Details/5
        /// <summary>
        /// Detailed view of person
        /// </summary>
        /// <param name="id">Person ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _bll.Persons.FirstOrDefaultAsync(id.Value);

            return View(person);
        }

        // GET: Persons/Create
        /// <summary>
        /// Person create view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create person
        /// </summary>
        /// <param name="person">Created person</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Nationality,Birthdate")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid();
                _bll.Persons.Add(person);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Persons/Edit/5
        /// <summary>
        /// Person edit view
        /// </summary>
        /// <param name="id">Person ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _bll.Persons.FirstOrDefaultAsync(id.Value);
            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Person edit view
        /// </summary>
        /// <param name="id">Person ID</param>
        /// <param name="person">Updated person</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Nationality,Birthdate")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Persons.Update(person);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PersonExists(person.Id))
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
            return View(person);
        }

        // GET: Persons/Delete/5
        /// <summary>
        /// Person delete view
        /// </summary>
        /// <param name="id">Person ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _bll.Persons.FirstOrDefaultAsync(id.Value);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Persons/Delete/5
        /// <summary>
        /// Delete person
        /// </summary>
        /// <param name="id">Person ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var person = await _bll.Persons.FirstOrDefaultAsync(id);
            _bll.Persons.Remove(person!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonExists(Guid id)
        {
            return await _bll.Persons.ExistsAsync(id);
        }
    }
}
