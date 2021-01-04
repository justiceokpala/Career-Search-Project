using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Tel { get; set; }

        public ICollection<JobSeeker> JobSeekers { get; set; }

        public ICollection<JobEmployer> Employer { get; set; }



        //public ICollection <JobEmployer> Employer { get; set; }
       // public ICollection<JobSeeker> JobSeeker { get; set; }





    }
}
