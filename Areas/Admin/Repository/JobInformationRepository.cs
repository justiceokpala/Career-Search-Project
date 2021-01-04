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
    public class JobInformationRepository : IJobInformationRepository
    {
        private readonly ApplicationDbContext _myJob;

        public JobInformationRepository(ApplicationDbContext myJob)
        {
            _myJob = myJob;
        }
        public async Task Add(JobInformation jobInformation)
        {
            await _myJob.JobInformations.AddAsync(jobInformation);
            await _myJob.SaveChangesAsync();
        }

        public async Task<JobInformation> Get(int id)
        {
            var jobInformation = await _myJob.JobInformations.FindAsync(id);
            return jobInformation;

        }

        public async Task<IEnumerable<JobInformation>> GetAll()
        {
            var jobInformatiom = await _myJob.JobInformations.OrderByDescending(a => a.Id).ToListAsync();
                return jobInformatiom;

        }

        public async Task Remove(int id)
        {
            var jobInformation = await _myJob.JobInformations.FindAsync(id);
            _myJob.JobInformations.Remove(jobInformation);
            _myJob.SaveChanges();
        }

        public async Task Update(JobInformation jobInformation)
        {
            _myJob.JobInformations.Update(jobInformation);
            await _myJob.SaveChangesAsync();
        }
    }
}
