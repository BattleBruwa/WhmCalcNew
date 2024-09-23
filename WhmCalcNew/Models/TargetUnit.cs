using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WhmCalcNew.Models
{
    public partial class TargetUnit: ObservableObject
    {
        [ObservableProperty]
        [property: Key]
        [property: StringLength(20, ErrorMessage = "Ошибка имени цели")]
        private string unitName;

        [MaxLength(3)]
        public byte Toughness { get; set; }

        [MaxLength(1)]
        public byte Save { get; set; }

        [MaxLength(3)]
        public byte Wounds { get; set; }

        [NotMapped]
        public string TargetProps { get => ToString(); }

        public override string ToString()
        {
            return $"{UnitName}\nT: {Toughness} Sv: {Save} W: {Wounds}";
        }
    }
}
