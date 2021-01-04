using Career_Search_Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.ViewModel
{
    public class JobSeekerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter your name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "please enter your age")]
        [DataType(DataType.Text)]
        public int Age { get; set; }

        [Required(ErrorMessage = "please enter your years of experience")]
        [DataType(DataType.Text)]
        public int YearsOfExperience { get; set; }

        [Required(ErrorMessage = "please enter experience level")]
        [DataType(DataType.Text)]
        public string ExperienceLevel { get; set; }

        [Required(ErrorMessage = "please enter job experience")]
        [DataType(DataType.Text)]
        public string Qualification { get; set; }
        public string Skills { get; set; }
        public string ContactInformation { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FunctionalAreaId { get; set; }
        public virtual FunctionalArea FunctionalArea { get; set; }
    }
}