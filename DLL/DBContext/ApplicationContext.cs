using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
	public class ApplicationContext : IdentityDbContext<User>
	{
		public ApplicationContext()
		{

		}
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{

		}

		public DbSet<Achievement> achievements { get; set; }
		public DbSet<User> users { get; set; }
		public DbSet<Developers> developers { get; set; }
		public DbSet<Client> clients { get; set; }
		public DbSet<Comments> comments { get; set; }
		public DbSet<Games> games { get; set; }
		public DbSet<Store> stores { get; set; }
		public DbSet<TypeGame> typeGames { get; set; }
		public DbSet<AchievementUser> achievementUsers { get; set; }
		public DbSet<DevelopersGames> developersGames { get; set; }
		public DbSet<GamesTypeGames> gamesTypeGames { get; set; }
		public DbSet<Cart> carts { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KillerOfSteam;Trusted_Connection=True;");
		}

		//Сделать метод для связи моделей по айди и изменить модели
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>().HasMany(c => c.Students)
        //        .WithMany(s => s.Courses)
        //        .Map(t => t.MapLeftKey("CourseId")
        //        .MapRightKey("StudentId")
        //        .ToTable("CourseStudent"));
        //}
    }
}
