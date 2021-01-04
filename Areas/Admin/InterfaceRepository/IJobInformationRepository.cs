using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository.Repository
{
    public interface IJobInformationRepository
    {
        Task<IEnumerable<JobInformation>> GetAll();
        Task<JobInformation> Get(int id);
        Task Remove(int id);
        Task Update(JobInformation jobInformation);
        Task Add(JobInformation jobInformation);
    }
}
