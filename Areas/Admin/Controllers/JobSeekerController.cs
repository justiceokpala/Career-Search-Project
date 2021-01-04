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
    public class JobSeekersController : Controller
    {
        private readonly ApplicationDbContext _repo;

        public JobSeekersController(ApplicationDbContext context)
        {
            _repo = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _repo.JobSeekers.Include(j => j.FunctionalArea);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobSeeker = await _repo.JobSeekers
            .Include(j => j.FunctionalArea)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return View(jobSeeker);
        }

        public IActionResult Create()
        {
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,YearsOfExperience,ExperienceLevel,Qualification,Skills,ContactInformation,UserId,FunctionalAreaId")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(jobSeeker);
                await _repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", jobSeeker.FunctionalAreaId);
            return View(jobSeeker);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSeeker = await _repo.JobSeekers.FindAsync(id);
            if (jobSeeker == null)
            {
                return NotFound();
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", jobSeeker.FunctionalAreaId);
            return View(jobSeeker);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,YearsOfExperience,ExperienceLevel,Qualification,Skills,ContactInformation,UserId,FunctionalAreaId")] JobSeeker jobSeeker)
        {
            if (id != jobSeeker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(jobSeeker);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", jobSeeker.FunctionalAreaId);
            return View(jobSeeker);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobSeeker = await _repo.JobSeekers
            .Include(j => j.FunctionalArea)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return View(jobSeeker);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobSeeker = await _repo.JobSeekers.FindAsync(id);
            _repo.JobSeekers.Remove(jobSeeker);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}