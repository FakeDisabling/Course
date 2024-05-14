using BLL.Interfaces;
using BLL.Mappers;
using BLL.Services;
using DAL;
using DAL.DBRepositories;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BLL
{
    public static class ConfigurateExtendions
    {
        public static void ConfigurateBLL(this IServiceCollection services, string connection)
        {
            services.ConfigureDALServices(connection);

            services.AddAutoMapper(
                typeof(AchievementProfile),
                typeof(AchievementUsersProfile),
                typeof(ClientProfile),
                typeof(CommentsProfile),
                typeof(DevelopersGamesProfile),
                typeof(DevelopersProfile),
                typeof(GamesProfile),
                typeof(StoreProfile),
                typeof(TypeGameProfile),
                typeof(UserProfile),
                typeof(GamesTypeGamesProfile),
                typeof(CartProfile)
            );

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IAchievementService, AchievementService>();
            services.AddTransient<IAchievementUserService, AchievementUsersService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IDevelopersService, DevelopersService>();
            services.AddTransient<IDevelopersGamesService, DevelopersGamesService>();
            services.AddTransient<IGamesService, GamesService>();
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<ITypeGameService, TypeGameService>();
            services.AddTransient<IUserService, UserService>();
			services.AddTransient<IGamesTypesGamesService, GamesTypeGamesService>();
            services.AddTransient<ICartService, CartService>();
		}
    }
}
