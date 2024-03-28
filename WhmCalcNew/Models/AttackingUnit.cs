using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WhmCalcNew.Models
{
    public class AttackingUnit : INotifyPropertyChanged
    {
        private string? _attacks;
        private byte? _accuracy;
        private byte? _strength;
        private byte? _armorPen;
        private string? _damage;

        public string? Attacks { get => _attacks; set { _attacks = value; OnPropertyChanged(); } }
        public byte? Accuracy { get => _accuracy; set { _accuracy = value; OnPropertyChanged(); } }
        public byte? Strength { get => _strength; set { _strength = value; OnPropertyChanged(); } }
        public byte? ArmorPen { get => _armorPen; set { _armorPen = value; OnPropertyChanged(); } }
        public string? Damage { get => _damage; set { _damage = value; OnPropertyChanged(); } }

        public AttackingUnit()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
