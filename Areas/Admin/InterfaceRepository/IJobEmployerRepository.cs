using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    public interface IJobEmployerRepository
    {
        Task<IEnumerable<JobEmployer>> GetAll();
        Task<JobEmployer> Get(int id);
        Task Remove(int id);
        Task Update(JobEmployer jobEmployer);
        Task Add(JobEmployer jobEmployer);
    }
}
