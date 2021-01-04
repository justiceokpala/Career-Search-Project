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
    public class JobInformationsController : Controller
    {
        private readonly ApplicationDbContext _repo;

        public JobInformationsController(ApplicationDbContext repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _repo.JobInformations.Include(j => j.FunctionalArea).Include(j => j.Industry).Include(j => j.JobType);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobInformation = await _repo.JobInformations
            .Include(j => j.FunctionalArea)
            .Include(j => j.Industry)
            .Include(j => j.JobType)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (jobInformation == null)
            {
                return NotFound();
            }

            return View(jobInformation);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id");
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id");
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FunctionalAreaId,JobLocation,AgeLimit,YearsOfExperience,Qualification,Requirements,Responsibility,JobSummary,IndustryId,Renumeration,CompanyId,JobTypeId")] JobInformation jobInformation)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(jobInformation);
                await _repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", jobInformation.FunctionalAreaId);
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", jobInformation.IndustryId);
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id", jobInformation.JobTypeId);
            return View(jobInformation);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobInformation = await _repo.JobInformations.FindAsync(id);
            if (jobInformation == null)
            {
                return NotFound();
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", jobInformation.FunctionalAreaId);
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", jobInformation.IndustryId);
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id", jobInformation.JobTypeId);
            return View(jobInformation);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FunctionalAreaId,JobLocation,AgeLimit,YearsOfExperience,Qualification,Requirements,Responsibility,JobSummary,IndustryId,Renumeration,CompanyId,JobTypeId")] JobInformation jobInformation)
        {
            if (id != jobInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(jobInformation);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", jobInformation.FunctionalAreaId);
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", jobInformation.IndustryId);
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id", jobInformation.JobTypeId);
            return View(jobInformation);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobInformation = await _repo.JobInformations
            .Include(j => j.FunctionalArea)
            .Include(j => j.Industry)
            .Include(j => j.JobType)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (jobInformation == null)
            {
                return NotFound();
            }

            return View(jobInformation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobInformation = await _repo.JobInformations.FindAsync(id);
            _repo.JobInformations.Remove(jobInformation);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}