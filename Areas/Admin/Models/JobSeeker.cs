using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Models
{
    public class JobSeeker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int YearsOfExperience { get; set; }
        public string ExperienceLevel { get; set; }
        public string Qualification { get; set; }
        public string Skills { get; set; }
        public string ContactInformation { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FunctionalAreaId { get; set; }
        public virtual FunctionalArea FunctionalArea { get; set; }
        

    }
}
