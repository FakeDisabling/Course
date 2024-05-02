using DAL.DBContext;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;
using DAL.Models;

namespace WebApplication1
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationContext context,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("Client") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Client"));
                context.SaveChanges();
            }
            if (await roleManager.FindByNameAsync("Moderator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Moderator"));
                context.SaveChanges();
            }
            if (await roleManager.FindByNameAsync("Developer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Developer"));
                context.SaveChanges();
            }
            string email = "client@mail.ru";
            string password = "Client1!";
            DateTime birthday = new DateTime(2004, 04, 13);
            string phonenumber = "+375297563392";
            string name = "client";
            string address = "5663 Jerrell Crossing";
            string email1 = "moderator@mail.ru";
            string password1 = "Moderator1!";
            DateTime birthday1 = new DateTime(2004, 03, 10);
            string phonenumber1 = "+375449925073";
            string name1 = "moderator";
            string address1 = "2170 Cronin Motorway";
            string email2 = "developer@mail.ru";
            string password2 = "Developer1!";
            DateTime birthday2 = new DateTime(2004, 07, 26);
            string phonenumber2 = "+375291506405";
            string name2 = "developer";
            string address2 = "8649 Hartmann Squares";
            User check = await userManager.FindByEmailAsync(email);
            if (await userManager.FindByEmailAsync(email) == null)
            {
                User client = new User
                {
                    Email = email,
                    Password = password,
                    UserName = name,
                    Birthday = birthday,
                    PhoneNumber = phonenumber,
                    Address = address
                };
                IdentityResult result = await userManager.CreateAsync(client, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(client, "Client");
                    context.SaveChanges();
                }
            }
            if (await userManager.FindByEmailAsync(email1) == null)
            {
                User moderator = new User
                {
                    Email = email1,
                    Password = password1,
                    UserName = name1,
                    Birthday = birthday1,
                    PhoneNumber = phonenumber1,
                    Address = address1
                };
                IdentityResult result = await userManager.CreateAsync(moderator, password1);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(moderator, "Moderator");
                    context.SaveChanges();
                }
            }
            if (await userManager.FindByEmailAsync(email2) == null)
            {
                User developer = new User
                {
                    Email = email2,
                    Password = password2,
                    UserName = name2,
                    Birthday = birthday2,
                    PhoneNumber = phonenumber2,
                    Address = address2
                };
                IdentityResult result = await userManager.CreateAsync(developer, password2);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(developer, "Developer");
                    context.SaveChanges();
                }
            }
        }
    }
}
