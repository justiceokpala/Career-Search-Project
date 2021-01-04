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
    public class JobEmployersController : Controller
    {
        private readonly ApplicationDbContext _repo;

        public JobEmployersController(ApplicationDbContext repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _repo.JobEmployers.Include(j => j.Industry).Include(j => j.TopJob);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobEmployer = await _repo.JobEmployers
            .Include(j => j.Industry)
            .Include(j => j.TopJob)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (jobEmployer == null)
            {
                return NotFound();
            }

            return View(jobEmployer);
        }

        [HttpGet]

        public IActionResult Create()
        {
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id");
            ViewData["TopJobId"] = new SelectList(_repo.TopJobs, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,IndustryId,UserId,TopJobId")] JobEmployer jobEmployer)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(jobEmployer);
                await _repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", jobEmployer.IndustryId);
            ViewData["TopJobId"] = new SelectList(_repo.TopJobs, "Id", "Id", jobEmployer.TopJobId);
            return View(jobEmployer);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEmployer = await _repo.JobEmployers.FindAsync(id);
            if (jobEmployer == null)
            {
                return NotFound();
            }
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", jobEmployer.IndustryId);
            ViewData["TopJobId"] = new SelectList(_repo.TopJobs, "Id", "Id", jobEmployer.TopJobId);
            return View(jobEmployer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,IndustryId,UserId,TopJobId")] JobEmployer jobEmployer)
        {
            if (id != jobEmployer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(jobEmployer);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", jobEmployer.IndustryId);
            ViewData["TopJobId"] = new SelectList(_repo.TopJobs, "Id", "Id", jobEmployer.TopJobId);
            return View(jobEmployer);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEmployer = await _repo.JobEmployers
            .Include(j => j.Industry)
            .Include(j => j.TopJob)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (jobEmployer == null)
            {
                return NotFound();
            }

            return View(jobEmployer);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobEmployer = await _repo.JobEmployers.FindAsync(id);
            _repo.JobEmployers.Remove(jobEmployer);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}