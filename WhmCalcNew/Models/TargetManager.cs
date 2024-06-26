﻿using System.Collections.ObjectModel;
using WhmCalcNew.Engine.DataProviders;

namespace WhmCalcNew.Models
{
    public class TargetManager
    {
        public static ObservableCollection<TargetUnit> _TargetsCollection { get; set; } = new ObservableCollection<TargetUnit>();

        public static ObservableCollection<TargetUnit> GetTargets()
        {
            return _TargetsCollection;
        }

        public static void FillCollection()
        {
            ExcelDataProvider.FillTargetCollection(_TargetsCollection);
        }

        static TargetManager()
        {
            FillCollection();
        }
    }
}
