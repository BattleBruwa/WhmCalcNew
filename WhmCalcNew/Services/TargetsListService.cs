using MvvmHelpers;
using WhmCalcNew.Models;
using WhmCalcNew.Services.DataAccess;

namespace WhmCalcNew.Services
{
    public class TargetsListService : ITargetsListService
    {
        public ObservableRangeCollection<TargetUnit> Targets { get; set; } = new();
        public IWhmDbService DbService { get; }

        public TargetsListService(IWhmDbService dbService)
        {
            DbService = dbService;
            Initialize();
        }

        private async Task Initialize()
        {
            Targets = new ObservableRangeCollection<TargetUnit>(await this.DbService.GetTargetsAsync());
        }
    }
}
