using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services
{
    public interface IModListService
    {
        List<Modificator> ModificatorsList { get; set; }
        ObservableCollection<Modificator> PickedMods { get; set; }

        // Привязки для кнопок модификаторов
        string SustainedHitsMod { set; }
        string CritsMod { set; }
        string AntiXMod { set; }
        string InvulMod { set; }
        string FnpMod { set; }
        // ---------------------------------

        Task InitializeModListAsync();
    }
}