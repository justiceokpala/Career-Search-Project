using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Career_Search_Project.Areas.Admin.Models;
using Career_Search_Project.Areas.Admin.Repository;

namespace Career_Search_Project.Controllers
{
    [Area("admin")]
    public class FunctionalAreasController : Controller
    {
        private readonly IFunctionAreaRepository _repo;

        public FunctionalAreasController(IFunctionAreaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var functionalArea = await _repo.Get(id);
            if (functionalArea == null)
            {
                return NotFound();
            }

            return View(functionalArea);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FunctionalArea functionalArea)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(functionalArea);
                return RedirectToAction(nameof(Index));
            }
            return View(functionalArea);
        }

        [HttpGet]
        public async Task<IActionResult> delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var functionalArea = await _repo.Get(id);
            if (functionalArea == null)
            {
                return NotFound();
            }
            return View(functionalArea);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")] FunctionalArea functionalArea)
        {
            if (id != functionalArea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(functionalArea);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(functionalArea);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var functionalArea = await _repo.Get(id);
            if (functionalArea == null)
            {
                return NotFound();
            }

            return View(functionalArea);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var functionalArea = await _repo.Get(id);
            await _repo.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }


}