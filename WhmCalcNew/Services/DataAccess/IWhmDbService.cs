using WhmCalcNew.Models;

namespace WhmCalcNew.Services.DataAccess
{
    public interface IWhmDbService
    {
        Task AddTargetAsync(TargetUnit target);
        Task DeleteTargetAsync(TargetUnit target);
        Task<List<TargetUnit>> GetTargetsAsync();
        Task<TargetUnit?> GetTargetByName(string name);
        Task UpdateTargetAsync(TargetUnit target);
    }
}