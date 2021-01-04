using Career_Search_Project.Areas.Admin.Data;
using Career_Search_Project.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository.Repository
{
    public class JobEmployerRepository : IJobEmployerRepository
    {
        private readonly ApplicationDbContext _myJob;

        public JobEmployerRepository(ApplicationDbContext myJob)
        {
            _myJob = myJob;
        }
        public async Task Add(JobEmployer jobEmployer)
        {
            await  _myJob.JobEmployers.AddAsync(jobEmployer);
            await _myJob.SaveChangesAsync();

        }

        public async Task<JobEmployer> Get(int id)
        {
            var jobEmployer = await _myJob.JobEmployers.FindAsync(id);
            return jobEmployer;
        }

        public async Task<IEnumerable<JobEmployer>> GetAll()
        {
            var jobEmployer = await _myJob.JobEmployers.OrderByDescending(a => a.Id).ToListAsync();
            return jobEmployer;

        }

        public async Task Remove(int id)
        {
            var jobEmployer = await _myJob.JobEmployers.FindAsync(id);
            _myJob.JobEmployers.Remove(jobEmployer);
            _myJob.SaveChanges();
        }

        public async Task Update(JobEmployer jobEmployer)
        {
            _myJob.JobEmployers.Update(jobEmployer);
            await _myJob.SaveChangesAsync();
        }
    }
}
