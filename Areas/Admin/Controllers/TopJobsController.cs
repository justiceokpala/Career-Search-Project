using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Career_Search_Project.Areas.Admin.Data;
using Career_Search_Project.Areas.Admin.Models;

namespace Career_Search_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TopJobsController : Controller
    {
        private readonly ApplicationDbContext _repo;

        public TopJobsController(ApplicationDbContext repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _repo.TopJobs.Include(a => a.FunctionalArea).Include(a => a.Industry).Include(a => a.JobType);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var topJob = await _repo.TopJobs
            .Include(t => t.FunctionalArea)
            .Include(t => t.Industry)
            .Include(t => t.JobType)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (topJob == null)
            {
                return NotFound();
            }

            return View(topJob);
        }

        public IActionResult Create()
        {
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id");
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id");
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FunctionalAreaId,JobLocation,AgeLimit,YearsOfExperience,Qualification,Requirements,Responsibility,JobSummary,IndustryId,Renumeration,CompanyId,JobTypeId")] TopJob topJob)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(topJob);
                await _repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", topJob.FunctionalAreaId);
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", topJob.IndustryId);
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id", topJob.JobTypeId);
            return View(topJob);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topJob = await _repo.TopJobs.FindAsync(id);
            if (topJob == null)
            {
                return NotFound();
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", topJob.FunctionalAreaId);
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", topJob.IndustryId);
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id", topJob.JobTypeId);
            return View(topJob);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FunctionalAreaId,JobLocation,AgeLimit,YearsOfExperience,Qualification,Requirements,Responsibility,JobSummary,IndustryId,Renumeration,CompanyId,JobTypeId")] TopJob topJob)
        {
            if (id != topJob.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(topJob);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", topJob.FunctionalAreaId);
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", topJob.IndustryId);
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id", topJob.JobTypeId);
            return View(topJob);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var topJob = await _repo.TopJobs
            .Include(t => t.FunctionalArea)
            .Include(t => t.Industry)
            .Include(t => t.JobType)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (topJob == null)
            {
                return NotFound();
            }

            return View(topJob);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topJob = await _repo.TopJobs.FindAsync(id);
            _repo.TopJobs.Remove(topJob);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}