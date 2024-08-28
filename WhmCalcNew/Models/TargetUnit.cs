using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhmCalcNew.Models
{
    public class TargetUnit
    {
        [Key, StringLength(20, ErrorMessage = "Ошибка имени цели")]
        public string UnitName { get; set; } = null!;

        [MaxLength(3)]
        public byte Toughness { get; set; }

        [MaxLength(1)]
        public byte Save { get; set; }

        [MaxLength(3)]
        public byte Wounds { get; set; }

        [NotMapped]
        public string TargetProps { get => this.ToString(); }

        public override string ToString()
        {
            return $"{this.UnitName}\nT: {this.Toughness} Sv: {this.Save} W: {this.Wounds}";
        }
    }
}
