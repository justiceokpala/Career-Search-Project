using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository.Repository
{
    public interface IJobSeekerRepository
    {
        Task<IEnumerable<JobSeeker>> GetAll();
        Task<JobSeeker> Get(int id);
        Task Remove(int id);
        Task Update(JobSeeker jobSeeker);
        Task Add(JobSeeker jobSeeker);
    }
}
