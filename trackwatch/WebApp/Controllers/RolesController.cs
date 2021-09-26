using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Role = BLL.App.DTO.Role;

namespace WebApp.Controllers
{
    /// <summary>
    /// RolesController
    /// </summary>
    public class RolesController : Controller
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// RolesController constructor
        /// </summary>
        /// <param name="bll"></param>
        public RolesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Roles
        /// <summary>
        /// Role index view. List all roles.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Roles.GetAllAsync());
        }

        // GET: Roles/Details/5
        /// <summary>
        /// Detailed view of role
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _bll.Roles.FirstOrDefaultAsync(id.Value);

            return View(role);
        }

        // GET: Roles/Create
        /// <summary>
        /// Role creation view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create role
        /// </summary>
        /// <param name="role">Created role</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                role.Id = Guid.NewGuid();
                _bll.Roles.Add(role);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        /// <summary>
        /// Role edit view
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _bll.Roles.FirstOrDefaultAsync(id.Value);
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit role
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <param name="role">Updated role</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Role role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Roles.Update(role);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RoleExists(role.Id))
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
            return View(role);
        }

        // GET: Roles/Delete/5
        /// <summary>
        /// Role delete view
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _bll.Roles.FirstOrDefaultAsync(id.Value);

            return View(role);
        }

        // POST: Roles/Delete/5
        /// <summary>
        /// Delete role
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var role = await _bll.Roles.FirstOrDefaultAsync(id);
            _bll.Roles.Remove(role!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RoleExists(Guid id)
        {
            return await _bll.Roles.ExistsAsync(id);
        }
    }
}
