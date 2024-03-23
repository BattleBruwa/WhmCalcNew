using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmCalcNew.Engine;
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
