using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.ViewModel
{
    public class AccountRegisterViewModel
    {
		[Required(ErrorMessage = "Please enter your full name")]
		[DataType(DataType.Text)]
		[StringLength(100, MinimumLength = 6, ErrorMessage = "Your fullname is too short")]
		public string FullName { get; set; }


		[Required(ErrorMessage = "Please enter your email address")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }


		[Required(ErrorMessage = "Please enter your password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }


		[Required(ErrorMessage = "Please confirm your password")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Passwords entered do not match")]
		public string ConfirmPassword { get; set; }


		[Required(ErrorMessage = "Please enter your phone number")]
		[DataType(DataType.PhoneNumber)]

		public string Tel { get; set; }


		[Required(ErrorMessage = "Please select user role")]
		[DataType(DataType.Text)]
		public string Role { get; set; }


		public ICollection<SelectListItem> UserRoles { get; set; } = new List<SelectListItem>();
	}
}
