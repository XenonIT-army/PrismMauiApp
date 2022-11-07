using Microsoft.EntityFrameworkCore;
using SqlLiteDBApp.Standard.Entities;
using SqlLiteDBApp.Standard.Interface;
using SqlLiteDBApp.Standard.Services;

namespace SqlLiteDBApp.Standard.Context
{
    public partial class MobileContext : DbContext
    {
        public DbSet<WordDB> Words { get; set; }

        public DbSet<PurchaseHistory> History { get; set; }
        public MobileContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DatabaseService service = new DatabaseService();


            optionsBuilder.EnableSensitiveDataLogging().UseSqlite($"Filename={AppSettings.DBPath}");
        }

       
    }
}
