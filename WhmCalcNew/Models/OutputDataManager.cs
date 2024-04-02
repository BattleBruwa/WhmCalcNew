using System.ComponentModel;
using System.Runtime.CompilerServices;
using WhmCalcNew.Engine.Calculations;

namespace WhmCalcNew.Models
{
    public class OutputDataManager : ObservableObject
    {
        #region Свойства
        private float? _hitsNum;
        public float? HitsNum
        {
            get => _hitsNum;
            set 
            {
                _hitsNum = value;
                OnPropertyChanged();
            }
        }

        private float? _woundsNum;
        public float? WoundsNum
        {
            get => _woundsNum;
            set
            {
                _woundsNum = value;
                OnPropertyChanged();
            }
        }

        private float? _unSavedNum;
        public float? UnSavedNum
        {
            get => _unSavedNum;
            set
            {
                _unSavedNum = value;
                OnPropertyChanged();
            }
        }

        private int? _deadModelsNum;
        public int? DeadModelsNum
        {
            get => _deadModelsNum;
            set
            {
                _deadModelsNum = value;
                OnPropertyChanged();
            }
        }

        private float? _totalDamageNum;
        public float? TotalDamageNum
        {
            get => _totalDamageNum;
            set
            {
                _totalDamageNum = value;
                OnPropertyChanged();
            }
        }
        #endregion


        public OutputDataManager()
        {

        }

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
            //float damage = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);
            //int? deadModels = 0;

            //if (damage < target.Wounds)
            //{
            //    for (int i = 1; i < this.UnSavedNum; i++)
            //    {
            //        float c = damage;
            //        while (c < target.Wounds && i < this.UnSavedNum)
            //        {
            //            i++;
            //            c = c + damage;
            //        }
            //        if (c >= target.Wounds)
            //        {
            //            deadModels++;
            //        }
            //    }

            //}
            //if (damage >= target.Wounds)
            //{
            //    deadModels = (int?)this.UnSavedNum;
            //}

            //this.DeadModelsNum = deadModels;
            this.DeadModelsNum = 99;
        }

        private void GetTotalDamage(AttackingUnit attacker, TargetUnit target)
        {
            this.TotalDamageNum = TotalDamageCalc.GetTotalDamage(attacker, target);
        }

        public void Recalculate(AttackingUnit? attacker, TargetUnit? target)
        {
            if (attacker != null && target != null)
            {
                this.GetHits(attacker, target);
                this.GetWounds(attacker, target);
                this.GetUnsavedWounds(attacker, target);
                this.GetDeadModels(attacker, target);
                this.GetTotalDamage(attacker, target);
            }
        }
    }
}
