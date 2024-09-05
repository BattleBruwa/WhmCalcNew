using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public class CalcOutputService : ICalcOutputService
    {
        #region Методы
        public float TotalAttacks(AttackingUnit attacker)
        {
            return AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
        }

        public double TotalHits(AttackingUnit attacker, ObservableCollection<Modificator> mods)
        {
            float sustainedHits = 0;
            float totalHits = 0;
            totalHits = TotalAttacks(attacker) * AccuracyCalc.ToHitRoll(attacker, mods);
            // Сус хитс и криты
            if (mods.Any(m => m.Id == 6 && m.Condition != null) && mods.Any(m => m.Id == 14 && m.Condition != null))
            {
                var susMod = mods.Single(m => m.Id == 6);
                var critMod = mods.Single(m => m.Id == 14);
                sustainedHits = totalHits * ((7f - (float)critMod.Condition) / 6f) * (float)susMod.Condition;
                totalHits += sustainedHits;
                return Math.Round(totalHits, 2);
            }
            // Сус хитс без критов
            if (mods.Any(m => m.Id == 6 && m.Condition != null))
            {
                var susMod = mods.Single(m => m.Id == 6);
                sustainedHits = totalHits * (1f / 6f) * (float)susMod.Condition;
                totalHits += sustainedHits;
                return Math.Round(totalHits, 2);
            }
            // Без сус хитов (c критом или без - разберется AccuracyCalc)
            return Math.Round(totalHits, 2);
        }

        public double TotalWounds(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods)
        {
            double lethalHits = 0;
            double totalWounds = 0;
            totalWounds = TotalHits(attacker, mods) * ToWoundCalc.ToWoundRoll(attacker, target, mods);
            // Леталки
            if (mods.Any(m => m.Id == 5))
            {
                // С критами
                if (mods.Any(m => m.Id == 14 && m.Condition != null))
                {
                    var critMod = mods.Single(m => m.Id == 14);
                    lethalHits = TotalHits(attacker, mods) * ((7f - (float)critMod.Condition) / 6f);
                    totalWounds = (TotalHits(attacker, mods) - lethalHits) * ToWoundCalc.ToWoundRoll(attacker, target, mods);
                    return Math.Round(totalWounds, 2);
                }
                // Без критов
                lethalHits = TotalHits(attacker, mods) * (1f / 6f);
                totalWounds = (TotalHits(attacker, mods) - lethalHits) * ToWoundCalc.ToWoundRoll(attacker, target, mods);
            }
            // Без леталок (c критом или без - разберется ToWoundCalc)
            return Math.Round(totalWounds, 2);
        }

        public double TotalUnSaved(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods)
        {
            double devWounds = 0;
            double totalUnsavedW = 0;
            totalUnsavedW = TotalWounds(attacker, target, mods) * ArmorSaveCalc.ToSaveRoll(attacker, target, mods);
            // Дев вунды
            // C анти х
            if (mods.Any(m => m.Id == 7) && mods.Any(m => m.Id == 9 && m.Condition != null))
            {
                var critMod = mods.Single(m => m.Id == 9);
                devWounds = TotalWounds(attacker, target, mods) * ((7f - (float)critMod.Condition) / 6f);
                totalUnsavedW = (TotalWounds(attacker, target, mods) - devWounds) * ArmorSaveCalc.ToSaveRoll(attacker, target, mods);
                return Math.Round(totalUnsavedW, 2);
            }
            // Без анти х
            if (mods.Any(m => m.Id == 7))
            {
                devWounds = TotalWounds(attacker, target, mods) * (1f / 6f);
                totalUnsavedW = (TotalWounds(attacker, target, mods) - devWounds) * ArmorSaveCalc.ToSaveRoll(attacker, target, mods);
                return Math.Round(totalUnsavedW, 2);
            }
            // Без дев вунд
            return Math.Round(totalUnsavedW, 2);
        }

        public double TotalDeadModels(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods)
        {
            double damagePerWound = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);
            // Если есть ополовинивание урона
            if (mods.Any(m => m.Id == 13))
            {
                damagePerWound = damagePerWound / 2;
                // -1 урон (применяется после деления)
                if (mods.Any(m => m.Id == 12))
                {
                    damagePerWound -= 1;
                }
                // Урон не может быть меньше 1
                if (damagePerWound < 1)
                {
                    damagePerWound = 1;
                }
            }
            double totalUnsavedW = TotalUnSaved(attacker, target, mods);
            double deadModels = 0;
            // ФНП
            if (mods.Any(m => m.Id == 10 && m.Condition != null))
            {
                var fnpMod = mods.Single(m => m.Id == 10);
                if (damagePerWound * ((7f - (float)fnpMod.Condition) / 6f) < target.Wounds)
                {
                    for (int i = 1; i < totalUnsavedW; i++)
                    {
                        double c = damagePerWound * ((7f - (float)fnpMod.Condition) / 6f);
                        while (c < target.Wounds && i < totalUnsavedW)
                        {
                            i++;
                            c += damagePerWound * ((7f - (float)fnpMod.Condition) / 6f);
                        }
                        if (c >= target.Wounds)
                        {
                            deadModels++;
                        }
                    }
                    return Math.Round(deadModels, 0);
                }
                if (damagePerWound * ((7f - (float)fnpMod.Condition) / 6f) >= target.Wounds)
                {
                    deadModels = totalUnsavedW;
                    return Math.Round(deadModels, 0);
                }
            }
            // Без ФНП
            if (damagePerWound < target.Wounds)
            {
                for (int i = 1; i < totalUnsavedW; i++)
                {
                    double c = damagePerWound;
                    while (c < target.Wounds && i < totalUnsavedW)
                    {
                        i++;
                        c += damagePerWound;
                    }
                    if (c >= target.Wounds)
                    {
                        deadModels++;
                    }
                }
                return Math.Round(deadModels, 0);
            }
            if (damagePerWound >= target.Wounds)
            {
                deadModels = totalUnsavedW;
                return Math.Round(deadModels, 0);
            }
            return Math.Round(deadModels, 0);
        }

        public double TotalDamage(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods)
        {
            double damagePerWound = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);
            if (mods.Any(m => m.Id == 13))
            {
                damagePerWound = damagePerWound / 2;
                // -1 урон (применяется после деления)
                if (mods.Any(m => m.Id == 12))
                {
                    damagePerWound -= 1;
                }
                // Урон не может быть меньше 1
                if (damagePerWound < 1)
                {
                    damagePerWound = 1;
                }
            }
            return Math.Round(TotalUnSaved(attacker, target, mods) * damagePerWound, 2);
        }
        #endregion
    }
}
