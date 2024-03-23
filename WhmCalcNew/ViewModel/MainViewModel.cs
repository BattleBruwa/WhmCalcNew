using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<TargetUnit> Targets { get; set; }

        public string DirPath { get; set; }

        public MainViewModel()
        {
            TargetManager.FillCollection();
            Targets = TargetManager.GetTargets();
        }
    }
}
