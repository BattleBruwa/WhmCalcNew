using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public interface ICalcOutputService
    {
        float TotalAttacks(AttackingUnit attacker);
        double TotalDamage(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods);
        double TotalDeadModels(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods);
        double TotalHits(AttackingUnit attacker, ObservableCollection<Modificator> mods);
        double TotalUnSaved(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods);
        double TotalWounds(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods);
    }
}