using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Welcome.Others;

namespace DataLayer.Database
{
    internal class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite("Data Source={databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.ID).ValueGeneratedOnAdd();

            var user = new DatabaseUser()
            {
                ID = 1,
                Name = "Pepi Piratkata",
                Password = "1233125415422",
                Role = UserRolesEnums.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };
            var user2 = new DatabaseUser()
            {
                ID = 2,
                Name = "Tedi Shmatkata",
                Password = "55555",
                Role = UserRolesEnums.STUDENT,
                Expires = DateTime.Now.AddYears(10)
            };
            var user3 = new DatabaseUser()
            {
                ID = 1,
                Name = "Kircho Kokoshkata",
                Password = "12345678abc",
                Role = UserRolesEnums.PROFESSOR,
                Expires = DateTime.Now.AddYears(10)
            };

            modelBuilder.Entity<DatabaseUser>()
                .HasData(user);
        }
        public DbSet<DatabaseUser> Users { get; set; }
    }
}
