﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using WhmCalcNew.Engine.Calculations;
using WhmCalcNew.Models;

namespace WhmCalcNew.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private ObservableCollection<TargetUnit>? _targets;
        public ObservableCollection<TargetUnit>? Targets
        {
            get { return _targets; }
            set
            {
                _targets = value;
            }
        }

        private TargetUnit? _selectedTarget;
        public TargetUnit? SelectedTarget
        {
            get { return _selectedTarget; }
            set
            {
                _selectedTarget = value;
                OnPropertyChanged();
                Recalculate(this.AttackingUnit, this.SelectedTarget);
            }
        }

        private AttackingUnit? _attackingUnit;
        public AttackingUnit? AttackingUnit
        {
            get { return _attackingUnit; }
            set
            {
                _attackingUnit = value;
                OnPropertyChanged();
                Recalculate(this.AttackingUnit, this.SelectedTarget);
            }
        }

        private OutputData? _outputData;

        public OutputData? OutputData
        {
            get { return _outputData; }
            set
            {
                _outputData = value;
                OnPropertyChanged();
                Recalculate(this.AttackingUnit, this.SelectedTarget);
            }
        }

        public MainViewModel()
        {
            this.Targets = TargetManager.GetTargets();
            this.AttackingUnit = new AttackingUnit();
            this.OutputData = OutputDataManager.GetOutputData();


            //TESTING!!!!!!!! ПОТОМ УДАЛИТЬ!!!!!!!!!
            Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    i++;
                    Debug.WriteLine(i.ToString());
                    Debug.WriteLine($"Attacker1: {AttackingUnit?.Attacks}, {AttackingUnit?.Accuracy}, {AttackingUnit?.Strength}, {AttackingUnit?.ArmorPen}, {AttackingUnit?.Damage}");
                    Debug.WriteLine($"Attacker2: {AttackingUnit?.HasRerollToHit1}, {AttackingUnit?.HasRerollToHitAll}, {AttackingUnit?.HasRerollToWound1}, {AttackingUnit?.HasRerollToWoundAll}, {AttackingUnit?.HasLethalHits}, {AttackingUnit?.HasSustainedHits}, {AttackingUnit?.HasDevastatingWounds}, {AttackingUnit?.IsMinusOneToWound}, {AttackingUnit?.HasCritsOn5s}");
                    Debug.WriteLine($"Target: {SelectedTarget?.Toughness}, {SelectedTarget?.Save}, {SelectedTarget?.Wounds}");
                    Debug.WriteLine($"Output: {OutputData?.HitsNum}, {OutputData?.WoundsNum}, {OutputData?.UnSavedNum}, {OutputData?.DeadModelsNum}, {OutputData?.TotalDamageNum}");
                    Thread.Sleep(1000);
                }
            });

        }

        private void Recalculate(AttackingUnit? attacker, TargetUnit? target)
        {
            if (attacker != null && target != null && this.OutputData != null)
            {
                OutputDataManager.GetHits(attacker);
                OutputDataManager.GetWounds(attacker, target);
                OutputDataManager.GetUnsavedWounds(attacker, target);
                OutputDataManager.GetDeadModels(attacker, target);
                OutputDataManager.GetTotalDamage(attacker, target);
            }
        }
    }
}
