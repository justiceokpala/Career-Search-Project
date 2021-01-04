using Career_Search_Project.Areas.Admin.Data;
using Career_Search_Project.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    public class WalkInRepository : IWalkInRepository
    {
        private readonly ApplicationDbContext _myJob;
        public WalkInRepository (ApplicationDbContext myJob)
        {
            _myJob = myJob;
        }
        public async Task Add(WalkIn walkIn)
        {
            await _myJob.WalkIns.AddAsync(walkIn);
            await _myJob.SaveChangesAsync();
        }

        public async Task<WalkIn> Get(int id)
        {
            var walkIn = await _myJob.WalkIns.FindAsync(id);
            return walkIn;
        }

        public async Task<IEnumerable<WalkIn>> GetAll()
        {
            var walkIn = await _myJob.WalkIns.OrderByDescending(a => a.Id).ToListAsync();
            return walkIn;
        }

        public async Task Remove(int id)
        {
            var walkIn = await _myJob.WalkIns.FindAsync(id);
            _myJob.WalkIns.Remove(walkIn);
            await _myJob.SaveChangesAsync();
        }

        public async Task Update(WalkIn walkIn)
        {
            _myJob.WalkIns.Update(walkIn);
            await _myJob.SaveChangesAsync();
        }
    }
}
