using Microsoft.EntityFrameworkCore;
using WhmCalcNew.Models;
using WhmCalcNew.Views;

namespace WhmCalcNew.Services.DataAccess
{
    public class WhmDbService : IWhmDbService
    {
        public async Task<IEnumerable<TargetUnit>> GetTargetsAsync()
        {
            using (var db = new DataContext())
            {
                try
                {
                    return await db.Targets.OrderBy(t => t.UnitName).ToListAsync();
                }
                catch (ArgumentNullException ex)
                {
                    var Message = new MessageWindow($"Failed to get targets from Database.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                    Message.ShowDialog();
                }
                catch (OperationCanceledException ex)
                {
                    var Message = new MessageWindow($"Failed to get targets from Database.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                    Message.ShowDialog();
                }
                return new List<TargetUnit>();
            }

        }

        public async Task<TargetUnit?> GetTargetByName(string name)
        {
            using (var db = new DataContext())
            {
                try
                {
                    if (await db.Targets.AnyAsync(t => t.UnitName == name))
                    {
                        return await db.Targets.SingleAsync(t => t.UnitName == name);
                    }
                    return null;
                }
                catch (ArgumentNullException ex)
                {
                    var Message = new MessageWindow($"Failed to get target from Database.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                    Message.ShowDialog();
                }
                catch (OperationCanceledException ex)
                {
                    var Message = new MessageWindow($"Failed to get target from Database.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                    Message.ShowDialog();
                }
                catch (InvalidOperationException ex)
                {
                    var Message = new MessageWindow($"Failed to get target from Database.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                    Message.ShowDialog();
                }
                catch (Exception ex)
                {
                    var Message = new MessageWindow($"Failed to get target from Database.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                    Message.ShowDialog();
                }
                return null;
            }
        }

        public async Task AddTargetAsync(TargetUnit target)
        {
            using (var db = new DataContext())
            {
                db.Targets.Add(target);
                await DBSaveChangesAsync(db);
            }
        }

        public async Task UpdateTargetAsync(TargetUnit target)
        {
            using (var db = new DataContext())
            {
                db.Targets.Update(target);
                await DBSaveChangesAsync(db);
            }
        }

        public async Task DeleteTargetAsync(TargetUnit target)
        {
            using (var db = new DataContext())
            {
                db.Targets.Remove(target);
                await DBSaveChangesAsync(db);
            }
        }


        private static async Task<int> DBSaveChangesAsync(DataContext db)
        {
            try
            {
                return await db.SaveChangesAsync();
            }
            catch (OperationCanceledException ex)
            {
                var Message = new MessageWindow($"Failed to save Database changes.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                Message.ShowDialog();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var Message = new MessageWindow($"Failed to save Database changes.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                Message.ShowDialog();
            }
            catch (DbUpdateException ex)
            {
                var Message = new MessageWindow($"Failed to save Database changes.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                Message.ShowDialog();
            }
            catch (Exception ex)
            {
                var Message = new MessageWindow($"Failed to save Database changes.\r\n{ex.Source}\r\n{ex.Message}", MessageType.Error);
                Message.ShowDialog();
            }
            return 0;
        }
    }
}
