using Career_Search_Project.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data source=CareerDB");
        }

        public DbSet <JobEmployer> JobEmployers { get; set; }
        public DbSet <JobInformation> JobInformations { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<User> UserRegistrations { get; set; }
        public DbSet<FunctionalArea> FunctionalAreas { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<TopJob> TopJobs { get; set; }
        public DbSet<WalkIn> WalkIns { get; set; }






    }
}
