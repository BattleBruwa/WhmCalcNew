using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public class CalcOutputService : ICalcOutputService
    {
        #region Свойства
        private double sustainedHits = 0d;
        private double lethalHits = 0d;
        private double devastatingWounds = 0d;
        private double damagePerWound = 0d;
        #endregion

        #region Методы частичного расчета
        private void TotalAttacks(AttackingUnit attacker, OutputData output)
        {
            output.AttacksNum = AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
        }
        // Вычисление SustainedHits
        private void SustainedHitsCalc(OutputData output, ObservableCollection<Modificator> mods)
        {
            var susHitsMod = mods.Single(m => m.Id == 6);
            byte susHitsCon = (byte)susHitsMod.Condition;
            // Без критов
            if (mods.Any(m => m.Id == 14) == false)
            {
                sustainedHits = output.AttacksNum * AccuracyCalc.ToHitRoll(6, mods) * susHitsCon;
                return;
            }
            // С критами
            if (mods.Any(m => m.Id == 14))
            {
                var critMod = mods.Single(m => m.Id == 14);
                byte critCon = (byte)critMod.Condition;

                sustainedHits = output.AttacksNum * AccuracyCalc.ToHitRoll(critCon, mods) * susHitsCon;
                return;
            }
        }
        // Вычисление LethalHits
        private void LethalHitsCalc(OutputData output, ObservableCollection<Modificator> mods)
        {
            // Без критов
            if (mods.Any(m => m.Id == 14) == false)
            {
                lethalHits = output.AttacksNum * AccuracyCalc.ToHitRoll(6, mods);
                return;
            }
            // С критами
            if (mods.Any(m => m.Id == 14))
            {
                var critMod = mods.Single(m => m.Id == 14);
                byte critCon = (byte)critMod.Condition;

                lethalHits = output.AttacksNum * AccuracyCalc.ToHitRoll(critCon, mods);
                return;
            }
        }
        // Вычисление DevastatingWounds
        private void DevWoundsCalc(OutputData output, ObservableCollection<Modificator> mods)
        {
            // Без Анти х
            if (mods.Any(m => m.Id == 9) == false)
            {
                devastatingWounds = output.HitsNum * ToWoundCalc.ToWoundRoll(6, mods);
                return;
            }
            // С Анти х
            if (mods.Any(m => m.Id == 9))
            {
                var critMod = mods.Single(m => m.Id == 9);
                byte critCon = (byte)critMod.Condition;

                devastatingWounds = output.HitsNum * ToWoundCalc.ToWoundRoll(critCon, mods);
                return;
            }
        }
        // Вычисление DamagePerWound
        private void DamagePerWoundCalc(AttackingUnit attacker, ObservableCollection<Modificator> mods)
        {
            double damage = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);
            // Если есть ополовинивание урона
            if (mods.Any(m => m.Id == 13))
            {
                damage = damage / 2;
            }
            // -1 урон
            if (mods.Any(m => m.Id == 12))
            {
                damage -= 1;
            }
            // Урон не может быть меньше 1
            if (damage < 1)
            {
                damage = 1;
            }
            damagePerWound = damage;
        }

        private void TotalHits(AttackingUnit attacker, OutputData output, ObservableCollection<Modificator> mods)
        {
            // Наличие реролов проверяет и обрабатывает AccuracyCalc.ToHitRoll
            // Если меткость 0, то автохиты
            if (attacker.Accuracy == 0)
            {
                output.HitsNum = output.AttacksNum;
                return;
            }
            // Проверка на SustainedHits
            if (mods.Any(m => m.Id == 6))
            {
                SustainedHitsCalc(output, mods);
            }
            else
            {
                sustainedHits = 0d;
            }
            // Проверка на LethalHits
            if (mods.Any(m => m.Id == 5))
            {
                LethalHitsCalc(output, mods);
            }
            else
            {
                lethalHits = 0d;
            }
            // Без критов
            if (mods.Any(m => m.Id == 14) == false)
            {
                output.HitsNum = output.AttacksNum * AccuracyCalc.ToHitRoll(attacker.Accuracy, mods) + sustainedHits - lethalHits;
                return;
            }
            // C критами
            if (mods.Any(m => m.Id == 14))
            {
                var critMod = mods.Single(m => m.Id == 14);
                byte critCon = (byte)critMod.Condition;
                // Если меткость лучше крита
                if (attacker.Accuracy <= critCon)
                {
                    output.HitsNum = output.AttacksNum * AccuracyCalc.ToHitRoll(attacker.Accuracy, mods) + sustainedHits - lethalHits;
                    return;
                }
                // Если меткость хуже крита
                if (attacker.Accuracy > critCon)
                {
                    output.HitsNum = output.AttacksNum * AccuracyCalc.ToHitRoll(critCon, mods) + sustainedHits - lethalHits;
                    return;
                }
            }
        }

        private void TotalWounds(AttackingUnit attacker, TargetUnit target, OutputData output, ObservableCollection<Modificator> mods)
        {
            // -1 ToWound и реролы обрабатываются в ToWoundCalc.ToWoundRoll
            byte resultedRoll = 0;

            if (attacker.Strength == target.Toughness)
            {
                resultedRoll = 4;
            }
            if (attacker.Strength > target.Toughness && attacker.Strength < target.Toughness * 2)
            {
                resultedRoll = 3;
            }
            if (attacker.Strength >= target.Toughness * 2)
            {
                resultedRoll = 2;
            }
            if (attacker.Strength < target.Toughness && attacker.Strength * 2 > target.Toughness)
            {
                resultedRoll = 5;
            }
            if (attacker.Strength * 2 <= target.Toughness)
            {
                resultedRoll = 6;
            }

            // Проверка на DevastatingWounds
            if (mods.Any(m => m.Id == 7))
            {
                DevWoundsCalc(output, mods);
            }
            else
            {
                devastatingWounds = 0d;
            }
            
            // С анти х
            if (mods.Any(m => m.Id == 9))
            {
                var critMod = mods.Single(m => m.Id == 9);
                byte critCon = (byte)critMod.Condition;
                // Если анти х лучше resultedRoll
                if (critCon <= resultedRoll)
                {
                    output.WoundsNum = output.HitsNum * ToWoundCalc.ToWoundRoll(critCon, mods) + lethalHits - devastatingWounds;
                    return;
                }
                // Если resultedRoll лучше анти х
                if (critCon > resultedRoll)
                {
                    output.WoundsNum = output.HitsNum * ToWoundCalc.ToWoundRoll(resultedRoll, mods) + lethalHits - devastatingWounds;
                    return;
                }
            }
            // Без анти х
            if (mods.Any(m => m.Id == 9) == false)
            {
                output.WoundsNum = output.HitsNum * ToWoundCalc.ToWoundRoll(resultedRoll, mods) + lethalHits - devastatingWounds;
                return;
            }
        }

        private void TotalUnSaved(AttackingUnit attacker, TargetUnit target, OutputData output, ObservableCollection<Modificator> mods)
        {
            // Инвуль обрабатывается в ArmorSaveCalc.ToSaveRoll
            double savedWounds = 0d;
            savedWounds = output.WoundsNum * ArmorSaveCalc.ToSaveRoll(attacker, target, mods);
            output.UnSavedNum = output.WoundsNum - savedWounds + devastatingWounds;
        }

        private void TotalDeadModels(AttackingUnit attacker, TargetUnit target, OutputData output, ObservableCollection<Modificator> mods)
        {
            DamagePerWoundCalc(attacker, mods);

            double deadModels = 0;
            // ФНП
            if (mods.Any(m => m.Id == 10))
            {
                var fnpMod = mods.Single(m => m.Id == 10);
                byte fnpCon = (byte)fnpMod.Condition;
                // Если урон с фнп меньше хп цели
                if (damagePerWound * ((7f - fnpCon) / 6f) < target.Wounds)
                {
                    for (int i = 1; i < output.UnSavedNum; i++)
                    {
                        double c = damagePerWound * ((7f - fnpCon) / 6f);
                        while (c < target.Wounds && i < output.UnSavedNum)
                        {
                            i++;
                            c += damagePerWound * ((7f - fnpCon) / 6f);
                        }
                        if (c >= target.Wounds)
                        {
                            deadModels++;
                        }
                    }
                    output.DeadModelsNum = deadModels;
                    return;
                }
                // Если урон с фнп больше или равен хп цели
                if (damagePerWound * ((7f - fnpCon) / 6f) >= target.Wounds)
                {
                    deadModels = output.UnSavedNum;
                    output.DeadModelsNum = deadModels;
                    return;
                }
            }
            // Без ФНП
            // Если урон меньше, чем хп цели
            if (damagePerWound < target.Wounds)
            {
                for (int i = 1; i < output.UnSavedNum; i++)
                {
                    double c = damagePerWound;
                    while (c < target.Wounds && i < output.UnSavedNum)
                    {
                        i++;
                        c += damagePerWound;
                    }
                    if (c >= target.Wounds)
                    {
                        deadModels++;
                    }
                }
                output.DeadModelsNum = deadModels;
                return;
            }
            // Если урон больше
            if (damagePerWound >= target.Wounds)
            {
                deadModels = output.UnSavedNum;
                output.DeadModelsNum = deadModels;
                return;
            }
        }

        private void TotalDamage(AttackingUnit attacker, OutputData output, ObservableCollection<Modificator> mods)
        {
            DamagePerWoundCalc(attacker, mods);

            output.TotalDamageNum = output.UnSavedNum * damagePerWound;
        }
        #endregion
        #region Главный метод расчета вывода
        public void CalculateOutput(AttackingUnit attacker, TargetUnit target, OutputData output, ObservableCollection<Modificator> mods)
        {
            sustainedHits = 0d;
            lethalHits = 0d;
            devastatingWounds = 0d;
            damagePerWound = 0d;
            TotalAttacks(attacker, output);
            TotalHits(attacker, output, mods);
            TotalWounds(attacker, target, output, mods);
            TotalUnSaved(attacker, target, output, mods);
            TotalDeadModels(attacker, target, output, mods);
            TotalDamage(attacker, output, mods);
        }
        #endregion
    }
}
