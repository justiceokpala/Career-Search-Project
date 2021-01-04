using Career_Search_Project.Areas.Admin.Data;
using Career_Search_Project.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Repository
{
    public class IndustryRepository : IIndustryRepository
    {
        private readonly ApplicationDbContext _myJob;

        public IndustryRepository (ApplicationDbContext myJob)
        {
            _myJob = myJob;
        }
        public async Task Add(Industry industry)
        {
            await _myJob.Industries.AddAsync(industry);
            await _myJob.SaveChangesAsync();
        }

        public async Task<Industry> Get(int id)
        {
            var industry = await _myJob.Industries.FindAsync(id);
            return industry;
        }

        public async Task<IEnumerable<Industry>> GetAll()
        {
            var industry = await _myJob.Industries.OrderByDescending(a => a.Id).ToListAsync();
            return industry;
        }

        public async Task Remove(int id)
        {
            var industries = await _myJob.Industries.FindAsync(id);
            _myJob.Industries.Remove(industries);
            _myJob.SaveChanges();
        }

        public async Task Update(Industry industry)
        {
            _myJob.Industries.Update(industry);
            await _myJob.SaveChangesAsync();
        }
    }
}
