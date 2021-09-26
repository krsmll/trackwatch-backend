using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLL.App.DTO;
using Contracts.BLL.App;

namespace WebApp.Controllers
{
    /// <summary>
    /// CoverPicturesController
    /// </summary>
    public class CoverPicturesController : Controller
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// CoverPicturesController constructor
        /// </summary>
        /// <param name="bll">bll</param>
        public CoverPicturesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: CoverPictures
        /// <summary>
        /// List all cover pictures
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _bll.CoverPictures.GetAllAsync());
        }

        // GET: CoverPictures/Details/5
        /// <summary>
        /// Detailed view of a cover picture
        /// </summary>
        /// <param name="id">Cover picture ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverPicture = await _bll.CoverPictures.FirstOrDefaultAsync(id.Value);

            return View(coverPicture);
        }

        // GET: CoverPictures/Create
        /// <summary>
        /// Redirect to cover picture creation page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: CoverPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create cover picture
        /// </summary>
        /// <param name="coverPicture">Created cover picture</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkId,URL")] CoverPicture coverPicture)
        {
            if (ModelState.IsValid)
            {
                coverPicture.Id = Guid.NewGuid();
                _bll.CoverPictures.Add(coverPicture);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", coverPicture.WorkId);
            return View(coverPicture);
        }

        // GET: CoverPictures/Edit/5
        /// <summary>
        /// Redirect to cover picture edit page
        /// </summary>
        /// <param name="id">Cover picture ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverPicture = await _bll.CoverPictures.FirstOrDefaultAsync(id.Value);

            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", coverPicture!.WorkId);
            return View(coverPicture);
        }

        // POST: CoverPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit cover picture
        /// </summary>
        /// <param name="id">Cover picture ID</param>
        /// <param name="coverPicture">Updated cover picture</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,WorkId,URL")] CoverPicture coverPicture)
        {
            if (id != coverPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.CoverPictures.Update(coverPicture);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CoverPictureExists(coverPicture.Id))
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

            ViewData["WorkId"] = new SelectList(await _bll.Works.GetAllAsync(), "Id", "Description", coverPicture.WorkId);
            return View(coverPicture);
        }

        // GET: CoverPictures/Delete/5
        /// <summary>
        /// Redirect to cover picture delete page
        /// </summary>
        /// <param name="id">Cover picture ID</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverPicture = await _bll.CoverPictures.FirstOrDefaultAsync(id.Value);

            return View(coverPicture);
        }

        // POST: CoverPictures/Delete/5
        /// <summary>
        /// Delete cover picture
        /// </summary>
        /// <param name="id">Cover picture ID</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var coverPicture = await _bll.CoverPictures.FirstOrDefaultAsync(id);
            _bll.CoverPictures.Remove(coverPicture!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CoverPictureExists(Guid id)
        {
            return await _bll.CoverPictures.ExistsAsync(id);
        }
    }
}