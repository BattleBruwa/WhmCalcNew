using MvvmHelpers;
using WhmCalcNew.Models;
using WhmCalcNew.Services.DataAccess;

namespace WhmCalcNew.Services
{
    public interface ITargetsListService
    {
        IWhmDbService DbService { get; }
        ObservableRangeCollection<TargetUnit> Targets { get; set; }
    }
}