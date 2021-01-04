using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    public interface IFunctionAreaRepository
    {
        Task<IEnumerable<FunctionalArea>> GetAll();
        Task<FunctionalArea> Get(int id);
        Task Remove(int id);
        Task Update(FunctionalArea functionalArea);
        Task Add(FunctionalArea functionalArea);
    }
}
