using System.IO;
using Microsoft.EntityFrameworkCore;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.DataAccess
{
    public class DataContext: DbContext
    {
        private readonly string dbPath = string.Concat(Path.GetFullPath("../../../Data"), "\\WhmUnitStatsDb.db3");

        public DbSet<TargetUnit> Targets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
