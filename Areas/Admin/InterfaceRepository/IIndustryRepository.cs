using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    interface IIndustryRepository
    {
        Task<IEnumerable<Industry>> GetAll();
        Task<Industry> Get(int id);
        Task Remove(int id);
        Task Update(Industry industry);
        Task Add(Industry industry);
    }
}
