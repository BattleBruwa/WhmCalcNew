using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmCalcNew.Models
{
    public class AttackingUnit
    {
        public string? Attacks { get; set; }
        public byte? Accuracy { get; set; }
        public byte? Strength { get; set; }
        public byte? ArmorPen { get; set; }

        public AttackingUnit() { }
    }
}
