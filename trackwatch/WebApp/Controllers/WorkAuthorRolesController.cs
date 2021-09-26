using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkAuthorRole = BLL.App.DTO.WorkAuthorRole;

namespace WebApp.Controllers
{
    /// <summary>
    /// WorkAuthorRolesController
    /// </summary>
    public class WorkAuthorRolesController : Controller
    {

        private readonly IAppBLL _bll;
        
        /// <summary>
        /// WorkAuthorRolesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public WorkAuthorRolesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkAuthorRoles
        /// <summary>
        /// Work author role index view. List all work author roles.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.WorkAuthorRoles.GetAllAsync());
        }

        // GET: WorkAuthorRoles/Details/5
        /// <summary>
        /// Detailed work author role view
        /// </summary>
        /// <param name="id">Work author role ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workAuthorRole = await _bll.WorkAuthorRoles.FirstOrDefaultAsync(id.Value);

            return View(workAuthorRole);
        }

        // GET: WorkAuthorRoles/Create
        /// <summary>
        /// Work author role creation view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["RoleId"] = new SelectList(await _bll.Roles.GetAllAsync(), "Id", "Name");
            ViewData["WorkAuthorId"] = new SelectList(await _bll.WorkAuthors.GetAllAsync(), "Id", "Id");
            return View();
        }

        // POST: WorkAuthorRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create work author role
        /// </summary>
        /// <param name="workAuthorRole">Created work author role</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkAuthorId,RoleId")] WorkAuthorRole workAuthorRole)
        {
            if (ModelState.IsValid)
            {
                workAuthorRole.Id = Guid.NewGuid();
                _bll.WorkAuthorRoles.Add(workAuthorRole);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(await _bll.Roles.GetAllAsync(), "Id", "Name", workAuthorRole.RoleId);
            ViewData["WorkAuthorId"] = new SelectList(await _bll.WorkAuthors.GetAllAsync(), "Id", "Id", workAuthorRole.WorkAuthorId);
            return View(workAuthorRole);
        }

        // GET: WorkAuthorRoles/Edit/5
        /// <summary>
        /// Work author role edit view
        /// </summary>
        /// <param name="id">Work author role ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workAuthorRole = await _bll.WorkAuthorRoles.FirstOrDefaultAsync(id.Value);
            ViewData["RoleId"] = new SelectList(await _bll.Roles.GetAllAsync(), "Id", "Name", workAuthorRole!.RoleId);
            ViewData["WorkAuthorId"] = new SelectList(await _bll.WorkAuthors.GetAllAsync(), "Id", "Id", workAuthorRole.WorkAuthorId);
            return View(workAuthorRole);
        }

        // POST: WorkAuthorRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit work author role
        /// </summary>
        /// <param name="id">Work author role ID</param>
        /// <param name="workAuthorRole">Updated work author role</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,WorkAuthorId,RoleId")] WorkAuthorRole workAuthorRole)
        {
            if (id != workAuthorRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.WorkAuthorRoles.Update(workAuthorRole);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WorkAuthorRoleExists(workAuthorRole.Id))
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
            ViewData["RoleId"] = new SelectList(await _bll.Roles.GetAllAsync(), "Id", "Name", workAuthorRole.RoleId);
            ViewData["WorkAuthorId"] = new SelectList(await _bll.WorkAuthors.GetAllAsync(), "Id", "Id", workAuthorRole.WorkAuthorId);
            return View(workAuthorRole);
        }

        // GET: WorkAuthorRoles/Delete/5
        /// <summary>
        /// Work author role delete view
        /// </summary>
        /// <param name="id">Work author role ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workAuthorRole = await _bll.WorkAuthorRoles.FirstOrDefaultAsync(id.Value);

            return View(workAuthorRole);
        }

        // POST: WorkAuthorRoles/Delete/5
        /// <summary>
        /// Delete work author role
        /// </summary>
        /// <param name="id">Work author role ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var workAuthorRole = await _bll.WorkAuthorRoles.FirstOrDefaultAsync(id);
            _bll.WorkAuthorRoles.Remove(workAuthorRole!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WorkAuthorRoleExists(Guid id)
        {
            return await _bll.WorkAuthorRoles.ExistsAsync(id);
        }
    }
}
