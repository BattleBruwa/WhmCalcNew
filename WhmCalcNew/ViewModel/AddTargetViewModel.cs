using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using WhmCalcNew.Models;
using WhmCalcNew.Services.DataAccess;

namespace WhmCalcNew.ViewModel
{
    public partial class AddTargetViewModel
    {
        public TargetUnit NewTarget { get; set; }
        public IWhmDbService DbService { get; }

        public AddTargetViewModel(IWhmDbService dbService)
        {
            DbService = dbService;
        }
        [RelayCommand]
        public async Task AddTarget()
        {
            // TODO: Оформить новое окно с подтверждением, если цель с таким именем уже существует
            if (await DbService.GetTargetByName(NewTarget.UnitName) == null)
            {
                await DbService.AddTargetAsync(NewTarget);
            }
            await DbService.UpdateTargetAsync(NewTarget);
        }


    }
}
