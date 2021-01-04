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
    public class WalkInsController : Controller
    {
        private readonly ApplicationDbContext _repo;

        public WalkInsController(ApplicationDbContext repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _repo.WalkIns.Include(w => w.FunctionalArea).Include(w => w.Industry).Include(w => w.JobType);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var walkIn = await _repo.WalkIns
            .Include(w => w.FunctionalArea)
            .Include(w => w.Industry)
            .Include(w => w.JobType)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (walkIn == null)
            {
                return NotFound();
            }

            return View(walkIn);
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
        public async Task<IActionResult> Create([Bind("Id,JobName,FunctionalAreaId,InterviewLocation,IndustryId,CompanyId,JobTypeId")] WalkIn walkIn)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(walkIn);
                await _repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", walkIn.FunctionalAreaId);
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", walkIn.IndustryId);
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id", walkIn.JobTypeId);
            return View(walkIn);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkIn = await _repo.WalkIns.FindAsync(id);
            if (walkIn == null)
            {
                return NotFound();
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", walkIn.FunctionalAreaId);
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", walkIn.IndustryId);
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id", walkIn.JobTypeId);
            return View(walkIn);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobName,FunctionalAreaId,InterviewLocation,IndustryId,CompanyId,JobTypeId")] WalkIn walkIn)
        {
            if (id != walkIn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(walkIn);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionalAreaId"] = new SelectList(_repo.FunctionalAreas, "Id", "Id", walkIn.FunctionalAreaId);
            ViewData["IndustryId"] = new SelectList(_repo.Industries, "Id", "Id", walkIn.IndustryId);
            ViewData["JobTypeId"] = new SelectList(_repo.JobTypes, "Id", "Id", walkIn.JobTypeId);
            return View(walkIn);
        }


        [HttpPost]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkIn = await _repo.WalkIns
            .Include(w => w.FunctionalArea)
            .Include(w => w.Industry)
            .Include(w => w.JobType)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (walkIn == null)
            {
                return NotFound();
            }

            return View(walkIn);
        }

        [HttpPost]

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var walkIn = await _repo.WalkIns.FindAsync(id);
            _repo.WalkIns.Remove(walkIn);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}