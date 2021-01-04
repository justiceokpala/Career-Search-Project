using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Models
{
    public class JobInformation
    { //This model saves Job information a company is willing to advertise
        public int Id { get; set; }
        public string Name { get; set; }
        public int FunctionalAreaId { get; set; }
        public virtual FunctionalArea FunctionalArea { get; set; }
        public string JobLocation { get; set; }
        public int AgeLimit { get; set; }
        public int YearsOfExperience { get; set; }
        public string Qualification { get; set; }
        public string Requirements { get; set; }
        public string Responsibility { get; set; }
        public string JobSummary { get; set; }
        public int IndustryId { get; set; }
        public decimal Renumeration { get; set; }
        public virtual Industry Industry { get; set; }
        public int CompanyId { get; set; }

        public int JobEmployerId { get; set; }
        public virtual JobEmployer JobEmployers { get; set; }
        public int JobTypeId { get; set; }
        public virtual JobType JobType { get; set; }



    }
}
