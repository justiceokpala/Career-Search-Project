using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    interface IJobTypeRepository
    {
        Task<IEnumerable<JobType>> GetAll();
        Task<JobType> Get(int id);
        Task Remove(int id);
        Task Update(JobType jobType);
        Task Add(JobType jobType);
    }
}
