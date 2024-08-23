using WhmCalcNew.Models;

namespace WhmCalcNew.Services.DataAccess
{
    public interface IWhmDbService
    {
        Task AddTargetAsync(TargetUnit target);
        Task DeleteTargetAsync(TargetUnit target);
        Task<List<TargetUnit>> GetTargetsAsync();
        Task UpdateTargetAsync(TargetUnit target);
    }
}