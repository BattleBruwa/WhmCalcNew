using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using WhmCalcNew.Models;
using WhmCalcNew.Services.DataAccess;

namespace WhmCalcNew.Services
{
    public partial class TargetsListService : ITargetsListService
    {
        public ObservableRangeCollection<TargetUnit> Targets { get; set; } = new();
        public IWhmDbService DbService { get; }

        public TargetsListService(IWhmDbService dbService)
        {
            DbService = dbService;
        }
        [RelayCommand]
        public async Task FillCollectionAsync()
        {
            Targets = new ObservableRangeCollection<TargetUnit>(await DbService.GetTargetsAsync());
        }
    }
}
