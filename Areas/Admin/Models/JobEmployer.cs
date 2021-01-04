using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Models
{
    public class JobEmployer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime FoundedOn { get; set; }
        public int IndustryId { get; set; }
        public virtual Industry Industry { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<JobInformation> JobInformations { get; set; }
        
        public ICollection<WalkIn> WalkIns { get; set; }

        public int TopJobId { get; set; }

        public virtual TopJob TopJob { get; set; }

    }
}
