using System.ComponentModel;
using WhmCalcNew.Engine;

namespace WhmCalcNew.Models
{
    public class OutputDataManager : INotifyPropertyChanged
    {
        public float? HitsNum { get; set; }
        public float? WoundsNum { get; set; }
        public float? UnSavedNum { get; set; }
        public int? DeadModelsNum { get; set; }
        public float? TotalDamageNum { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void GetHits(AttackingUnit attacker, TargetUnit target)
        {
            float attacks = AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
            float hitProb = AccuracyCalc.ToHitRoll(attacker, target);

            this.HitsNum = attacks * hitProb;
        }

        private void GetWounds(AttackingUnit attacker, TargetUnit target)
        {
            float woundProb = ToWoundCalc.ToWoundRoll(attacker, target);

            this.WoundsNum = this.HitsNum * woundProb;
        }

        private void GetUnsavedWounds(AttackingUnit attacker, TargetUnit target)
        {
            float saveProp = ArmorSaveCalc.ToSaveRoll(attacker, target);

            this.UnSavedNum = this.WoundsNum - (saveProp * this.WoundsNum);
        }

        private void GetDeadModels(AttackingUnit attacker, TargetUnit target)
        {
            float damage = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);
            int? deadModels = 0;

            if (damage < target.Wounds)
            {
                for (int i = 1; i < this.UnSavedNum; i++)
                {
                    float c = damage;
                    while (c < target.Wounds && i < this.UnSavedNum)
                    {
                        i++;
                        c = c + damage;
                    }
                    if (c >= target.Wounds)
                    {
                        deadModels++;
                    }
                }

            }
            if (damage >= target.Wounds)
            {
                deadModels = (int?)this.UnSavedNum;
            }

            this.DeadModelsNum = deadModels;
        }

        private void GetTotalDamage(AttackingUnit attacker, TargetUnit target)
        {
            this.TotalDamageNum = TotalDamageCalc.GetTotalDamage(attacker, target);
        }

        public void Recalculate(AttackingUnit attacker, TargetUnit target)
        {
            this.GetHits(attacker, target);
            this.GetWounds(attacker, target);
            this.GetUnsavedWounds(attacker, target);
            this.GetDeadModels(attacker, target);
            this.GetTotalDamage(attacker, target);
        }
    }
}
