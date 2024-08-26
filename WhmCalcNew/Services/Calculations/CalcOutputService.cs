using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public class CalcOutputService
    {
        private float _sustainedHits;
        private float _lethalHits;

        public float TotalAttacks(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods)
        {
            return AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
        }

        public float TotalHits(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods)
        {
            // Сус хитс и криты
            if (mods.Any(m => m.Id == 6 && m.Condition != null) && mods.Any(m => m.Id == 14 && m.Condition != null))
            {
                var modWithSus = mods.Single(m => m.Id == 6);
                var modWithCrit = mods.Single(m => m.Id == 14);
                float totalHits = 0;

                totalHits = TotalAttacks(attacker, target, mods) * AccuracyCalc.ToHitRoll(attacker, mods);

                _sustainedHits = totalHits * ((7f - (float)modWithCrit.Condition)/6f) * (float)modWithSus.Condition;

                totalHits += _sustainedHits;
                _sustainedHits = 0;

                return totalHits;
            }
        }
    }
}
