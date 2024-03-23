using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WhmCalcNew.Engine;

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
    }
}
