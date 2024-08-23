﻿using Microsoft.EntityFrameworkCore;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.DataAccess
{
    public class WhmDbService : IWhmDbService
    {
        public async Task<List<TargetUnit>> GetTargetsAsync()
        {
            using (var db = new DataContext())
            {
                return await db.Targets.OrderBy(t => t.UnitName).ToListAsync();
            }
        }

        public async Task AddTargetAsync(TargetUnit target)
        {
            using (var db = new DataContext())
            {
                await db.Targets.AddAsync(target);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateTargetAsync(TargetUnit target)
        {
            using (var db = new DataContext())
            {
                db.Targets.Update(target);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteTargetAsync(TargetUnit target)
        {
            using (var db = new DataContext())
            {
                db.Targets.Remove(target);
                await db.SaveChangesAsync();
            }
        }
    }
}
