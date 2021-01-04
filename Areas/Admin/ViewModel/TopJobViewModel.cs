using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.ViewModel
{
    public class TopJobViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "first name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a functional area")]
        [Display(Name = "funtional area")]
        [DataType(DataType.Text)]
        public int FunctionalAreaId { get; set; }
        public virtual FunctionalArea FunctionalArea { get; set; }
        public string JobLocation { get; set; }

        [Required(ErrorMessage = "please input age limit")]
        [DataType(DataType.Text)]
        public int AgeLimit { get; set; }

        [Required(ErrorMessage = "please input years of experience")]
        [DataType(DataType.Text)]
        public int YearsOfExperience { get; set; }

        [Required(ErrorMessage = "please input maximum qualification")]
        [DataType(DataType.Text)]
        public string Qualification { get; set; }

        public string Requirements { get; set; }
        public string Responsibility { get; set; }
        public string JobSummary { get; set; }
        public int IndustryId { get; set; }
        public decimal Renumeration { get; set; }
        public virtual Industry Industry { get; set; }
        public int CompanyId { get; set; }
        public virtual JobEmployer JobEmployer { get; set; }
        public int JobTypeId { get; set; }
        public virtual JobType JobType { get; set; }
    }
}