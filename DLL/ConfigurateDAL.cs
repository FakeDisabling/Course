using DAL.DBContext;
using DAL.DBRepositories;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ConfigurateDAL
    {
        public static void ConfigureDALServices(this IServiceCollection services, string connString)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connString));
            services.AddTransient<IAchievement, AchievementRepositories>();
            services.AddTransient<IAchievementUser, AchievementUserRepositories>();
            services.AddTransient<IClient, ClientRepositories>();
            services.AddTransient<IComment, CommentRepositories>();
            services.AddTransient<IDevelopers, DevelopersRepositories>();
            services.AddTransient<IDevelopersGames, DevelopersGamesRepositories>();
            services.AddTransient<IGames, GamesRepositories>();
            services.AddTransient<IStore, StoreRepositories>();
            services.AddTransient<ITypeGame, TypeGameRepositories>();
            services.AddTransient<IUser, UserRepositories>();
            services.AddTransient<IGamesTypeGames, GameTypeGamesRepository>();
            services.AddTransient<ICart, CartRepositories>();
        }
    }
}
