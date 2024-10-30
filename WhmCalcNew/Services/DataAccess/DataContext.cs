using System.IO;
using Microsoft.EntityFrameworkCore;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.DataAccess
{
    public class DataContext: DbContext
    {
        private readonly string dbPath = string.Concat("Data Source=", Path.GetFullPath("../../../Data"), "\\WhmUnitStatsDb.db3");

        public DbSet<TargetUnit> Targets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(dbPath);

            //"Data Source=WhmUnitStatsDb.db3"
        }
    }
}
