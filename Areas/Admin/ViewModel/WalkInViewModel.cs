﻿using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.ViewModel
{
    public class WalkInViewModel
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public int FunctionalAreaId { get; set; }
        public virtual FunctionalArea FunctionalArea { get; set; }
        public string InterviewLocation { get; set; }
        public int IndustryId { get; set; }
        public virtual Industry Industry { get; set; }
        public int CompanyId { get; set; }
        public virtual JobEmployer JobEmployer { get; set; }
        public int JobTypeId { get; set; }
        public virtual JobType JobType { get; set; }
    }
}