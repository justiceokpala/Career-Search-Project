using Career_Search_Project.Areas.Admin.Data;
using Career_Search_Project.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    public class TopJobRepository : ITopJobRepository
    {
        private readonly ApplicationDbContext _myJob;
        public TopJobRepository(ApplicationDbContext myJob)
        {
            _myJob = myJob;
        }
        public async Task Add(TopJob topJob)
        {
            await _myJob.TopJobs.AddAsync(topJob);
            await _myJob.SaveChangesAsync();
        }

        public async Task<TopJob> Get(int id)
        {
            var topJob = await _myJob.TopJobs.FindAsync(id);
            return topJob;
        }

        public async Task<IEnumerable<TopJob>> GetAll()
        {
            var topJob = await _myJob.TopJobs.OrderByDescending(a => a.Id).ToListAsync();
            return topJob;
        }

        public async Task Remove(int id)
        {
            var topJob = await _myJob.TopJobs.FindAsync(id);
            _myJob.TopJobs.Remove(topJob);
            await _myJob.SaveChangesAsync();
        }

        public async Task Update(TopJob topJob)
        {
            _myJob.TopJobs.Update(topJob);
            await _myJob.SaveChangesAsync();
        }
    }
}
