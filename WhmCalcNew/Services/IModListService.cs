using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services
{
    public interface IModListService
    {
        List<Modificator> ModificatorsList { get; set; }
        ObservableCollection<Modificator> PickedMods { get; set; }
        string SustainedHitsMod { set; }
        Task InitializeModListAsync();
    }
}