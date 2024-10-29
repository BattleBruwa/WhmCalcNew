using Microsoft.EntityFrameworkCore;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.DataAccess
{
    public class DataContext: DbContext
    {
        public DbSet<TargetUnit> Targets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WhmUnitStatsDb.db3");
        }
    }
}
