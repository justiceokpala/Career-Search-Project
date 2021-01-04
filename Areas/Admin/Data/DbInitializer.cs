using Career_Search_Project.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Data
{
    public static class DbInitializer
    {
		public static async Task SeedDataAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			await SeedRolesAsync(roleManager);

			await SeedUsersAsync(userManager);

		}

		public static async Task SeedUsersAsync(UserManager<User> userManager)
		{
			var result = await userManager.FindByEmailAsync("james_stuart@gmail.com");
			if (result == null)
			{
				var user = new User
				{
					FullName = "James Awuru",
					Email = "mondayjamesawuru10@gmail.com",
					UserName = "mondayjamesawuru10@gmail.com",
					Tel = "08187858318"
				};

				await userManager.CreateAsync(user, "JamesAwuru2020@");

				await userManager.AddToRoleAsync(user, "Administrator");


				var user3 = new User
				{
					FullName = "Justice Okpala",
					Email = "justice@gmail.com",
					UserName = "justice@gmail.com",
					Tel = "08187858318"
				};

				await userManager.CreateAsync(user3, "JamesAwuru2020@");

				await userManager.AddToRoleAsync(user3, "JobEmployer");


				var user2 = new User
				{
					FullName = "Temidayo S. Adebambo",
					Email = "teechamp@gmail.com",
					UserName = "teechamp@gmail.com",
					Tel = "08187858318"
				};

				await userManager.CreateAsync(user2, "Secret123@");

				await userManager.AddToRoleAsync(user2, "JobSeeker");
			}
		}

		public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
		{
			var result = await roleManager.RoleExistsAsync("Administrator");
			if (!result)
			{
				await roleManager.CreateAsync(new IdentityRole { Name = "Administrator" });
			}
			result = await roleManager.RoleExistsAsync("JobSeeker");

			if (!result)
			{
				await roleManager.CreateAsync(new IdentityRole { Name = "JobSeeker" });
			}

			result = await roleManager.RoleExistsAsync("JobEmployer");

			if (!result)
			{
				await roleManager.CreateAsync(new IdentityRole { Name = "JobEmployer" });
			}
		}
	}
}
