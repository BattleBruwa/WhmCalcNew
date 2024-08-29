using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services
{
    public interface IModListService
    {
        static List<Modificator> ModificatorsList { get; set; }
        ObservableCollection<Modificator> PickedModificators { get; set; }
    }
}