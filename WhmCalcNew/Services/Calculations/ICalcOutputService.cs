using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public interface ICalcOutputService
    {
        void CalculateOutput(AttackingUnit attacker, TargetUnit target, OutputData output, ObservableCollection<Modificator> mods);
    }
}