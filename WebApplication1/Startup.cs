using BLL.Interfaces;
using DAL.DBContext;
using DAL.DBRepositories;
using DAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebApplication1.Models;
using BLL;
using BLL.Services;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var json = File.ReadAllText("D:\\Семестр 6\\Курсач ИГИ\\Прога\\WebApplication1\\WebApplication1\\ConnectionSting.json");
            var appSettings = JsonConvert.DeserializeObject<AppSettings>(json);
            string connectionString = appSettings.ConnectionString;
            services.ConfigurateBLL(connectionString);
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

            services.AddScoped<IClient, ClientRepositories>();
            services.AddScoped<IAchievement, AchievementRepositories>();
            services.AddScoped<IAchievementUser, AchievementUserRepositories>();
            services.AddScoped<IComment, CommentRepositories>();
            services.AddScoped<IDevelopers, DevelopersRepositories>();
            services.AddScoped<IDevelopersGames, DevelopersGamesRepositories>();
            services.AddScoped<IGames, GamesRepositories>();
            services.AddScoped<IStore, StoreRepositories>();
            services.AddScoped<ITypeGame, TypeGameRepositories>();
            services.AddScoped<IGamesTypeGames, GameTypeGamesRepository>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAchievementService, AchievementService>();
            services.AddScoped<IAchievementUserService, AchievementUsersService>();
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<IDevelopersService, DevelopersService>();
            services.AddScoped<IDevelopersGamesService, DevelopersGamesService>();
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ITypeGameService, TypeGameService>();
			services.AddScoped<IGamesTypesGamesService, GamesTypeGamesService>();

			services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    DbInitializer.InitializeAsync(context, userManager, rolesManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ошибка при инициализации базы данных");
                }
            }
        }
    }
}
