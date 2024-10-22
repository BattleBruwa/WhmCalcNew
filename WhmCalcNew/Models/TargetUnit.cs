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

        [ObservableProperty]
        [property: MaxLength(3)]
        private byte toughness;

        [ObservableProperty]
        [property: MaxLength(1)]
        private byte save;

        [ObservableProperty]
        [property: MaxLength(3)]
        private byte wounds;

        [NotMapped]
        public string TargetProps { get => ToString(); }

        public override string ToString()
        {
            return $"{UnitName}\nT: {Toughness} Sv: {Save} W: {Wounds}";
        }
    }
}
