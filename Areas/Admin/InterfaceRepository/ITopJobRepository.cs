using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    interface ITopJobRepository
    {
        Task<IEnumerable<TopJob>> GetAll();
        Task<TopJob> Get(int id);
        Task Remove(int id);
        Task Update(TopJob topJob);
        Task Add(TopJob topJob);
    }
}
