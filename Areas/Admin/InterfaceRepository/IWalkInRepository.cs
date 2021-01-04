using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    interface IWalkInRepository
    {
        Task<IEnumerable<WalkIn>> GetAll();
        Task<WalkIn> Get(int id);
        Task Remove(int id);
        Task Update(WalkIn walkIn);
        Task Add(WalkIn walkIn);
    }
}
