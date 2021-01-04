using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Models
{
    public class JobType
    {
        public string FullTime { get; set; }
        public string PartTime { get; set; }
        public string Temporary { get; set; }
        public string Contract { get; set; }
        public int Id { get;  set; }

        public ICollection<JobInformation> JobInformations { get; set; }

        public ICollection<TopJob> TopJobs { get; set; }

        public ICollection<WalkIn> WalkIns { get; set; }
    }
}
