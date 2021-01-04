using Career_Search_Project.Areas.Admin.Data;
using Career_Search_Project.Areas.Admin.Models;
using Career_Search_Project.Areas.Admin.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    public class JobSeekerRepository : IJobSeekerRepository
    {
        private readonly ApplicationDbContext _myJob;
        public JobSeekerRepository(ApplicationDbContext myJob)
        {
            _myJob = myJob;
        }

        public async Task Add(JobSeeker jobSeeker) 
        {
            await _myJob.JobSeekers.AddAsync(jobSeeker);
            await _myJob.SaveChangesAsync();
        }

        public async Task<JobSeeker> Get(int id)
        {
            var jobseeker = await _myJob.JobSeekers.FindAsync(id);
            return jobseeker;
        }

        public async Task<IEnumerable<JobSeeker>> GetAll()
        {
            var joSeeker = await _myJob.JobSeekers.OrderByDescending(a => a.Id).ToListAsync();
            return joSeeker;
        }

        public async Task Remove(int id)
        {
            var jobSeeker = await _myJob.JobSeekers.FindAsync(id);
            _myJob.JobSeekers.Remove(jobSeeker);
            await _myJob.SaveChangesAsync();
        }

        public async Task Update(JobSeeker jobSeeker)
        {
            _myJob.JobSeekers.Update(jobSeeker);
            await _myJob.SaveChangesAsync();
        }
    }
}
