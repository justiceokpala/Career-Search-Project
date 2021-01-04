using Career_Search_Project.Areas.Admin.Data;
using Career_Search_Project.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    public class JobTypeRepository : IJobTypeRepository
    {
        private readonly ApplicationDbContext _myJob;
        public JobTypeRepository(ApplicationDbContext myJob)
        {
            _myJob = myJob;
        }
        public async Task Add(JobType jobType)
        {
            await _myJob.JobTypes.AddAsync(jobType);
            await _myJob.SaveChangesAsync();
        }

       

        public async Task<JobType> Get(int id)
        {
            var jobType = await _myJob.JobTypes.FindAsync(id);
            return jobType;
        }

        public async Task<IEnumerable<JobType>> GetAll()
        {
            var jobType = await _myJob.JobTypes.OrderByDescending(a => a.Id).ToListAsync();
            return jobType;
        }

        public async Task Remove(int id)
        {
            var jobType = await _myJob.JobTypes.FindAsync(id);
            _myJob.JobTypes.Remove(jobType);
            await _myJob.SaveChangesAsync();
        }

        public async Task Update(JobType jobType)
        {
            _myJob.JobTypes.Update(jobType);
            await _myJob.SaveChangesAsync();
        }

        
    }
}
