using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.ViewModel
{
    public class MainViewModel
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

        private AttackingUnit? _attackingUnit;
        public AttackingUnit? AttackingUnit
        {
            get { return _attackingUnit; }
            set
            {
                _attackingUnit = value;
            }
        }

        public float CalculatedDamage { get; set; }

        public MainViewModel()
        {
            TargetManager.FillCollection();
            Targets = TargetManager.GetTargets();
            AttackingUnit = new AttackingUnit();
            
        }
    }
}
