using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PinkMilkMedia.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PinkMilkMedia.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PinkMilkMediaContext(
                serviceProvider.GetRequiredService<DbContextOptions<PinkMilkMediaContext>>()))
            {
                    string UserId = null;
                    var userEmail = "admin@test.com";
                    var userManager = serviceProvider.GetService<UserManager<Owner>>();
                    var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

                    if (!context.Roles.Any())
                    {
                        var roleResult = await roleManager
                            .CreateAsync(new IdentityRole() { Name = Constants.Roles.Admin });
                        roleResult = await roleManager
                                .CreateAsync(new IdentityRole() { Name = Constants.Roles.User });
                    }



                    if (!context.Users.Any())
                    {
                        var user = new Owner()
                        {
                            FirstName = "Admin",
                            LastName = "Super",
                            Email = userEmail,
                            UserName = userEmail
                        };

                        var result = await userManager.CreateAsync(user, "password");
                        if (!result.Succeeded)
                        {
                            throw new Exception();
                        }

                        user = await userManager.FindByEmailAsync(userEmail);
                        UserId = await userManager.GetUserIdAsync(user);

                        await userManager.AddToRoleAsync(user, Constants.Roles.Admin);
                    }

                    if (UserId == null)
                    {
                        var user = await userManager.FindByEmailAsync(userEmail);
                        UserId = user.Id;
                    }

                    context.SaveChanges();
                

                
            }
        }
    }
}
