using Career_Search_Project.Areas.Admin.Data;
using Career_Search_Project.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    public class FunctionAreaRepository : IFunctionAreaRepository
    {
        private readonly ApplicationDbContext _myJob;

        public FunctionAreaRepository(ApplicationDbContext myJob)
        {
            _myJob = myJob;
        }
        public async Task Add(FunctionalArea functionalArea)
        {
            await _myJob.FunctionalAreas.AddAsync(functionalArea);
            await _myJob.SaveChangesAsync();
        }

        public async Task<FunctionalArea> Get(int id)
        {
            var functionalArea = await _myJob.FunctionalAreas.FindAsync(id);
            return functionalArea;
        }

        public async Task<IEnumerable<FunctionalArea>> GetAll()
        {
            var functionalArea = await _myJob.FunctionalAreas.OrderByDescending(a => a.Id).ToListAsync();
            return functionalArea;
        }

        public async Task Remove(int id)
        {
            var functionalArea = await _myJob.FunctionalAreas.FindAsync(id);
            _myJob.FunctionalAreas.Remove(functionalArea);
            _myJob.SaveChanges();
        }

        public async Task Update(FunctionalArea functionalArea)
        {
            _myJob.FunctionalAreas.Update(functionalArea);
            await _myJob.SaveChangesAsync();
        }
    }
}
