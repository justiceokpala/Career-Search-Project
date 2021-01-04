using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Controllers
{[Area("Admin")]
    public class DashboardController : Controller
    {
		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		// /admin/dashboard/anybody
		public IActionResult AnyBody()
		{
			return Content("This page can be accessed by anybody");
		}

		public IActionResult OnlyAuthorizedUsers()
		{
			return Content("This page can only be accessed by an authorized user!");
		}
	}
}
