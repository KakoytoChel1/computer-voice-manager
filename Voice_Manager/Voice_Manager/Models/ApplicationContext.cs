using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voice_Manager.Models.DataBaseItemsAndLogic;

namespace Voice_Manager.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<File> Files => Set<File>();
        public DbSet<Site> Sites => Set<Site>();
        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<Control> Controls => Set<Control>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MainDataBase.db");
        }
    }
}