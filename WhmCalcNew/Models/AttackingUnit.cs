using System.ComponentModel.DataAnnotations;
using MvvmHelpers;

namespace WhmCalcNew.Models
{
    public partial class AttackingUnit: ObservableObject
    {
        #region Свойства

        // Количество атак
        private string _attacks = "0";
        [StringLength(10)]
        public string Attacks
        {
            get { return _attacks; }
            set
            {
                SetProperty(ref _attacks, value);
            }
        }

        // WS/BS меткость атак
        private byte _accuracy;
        [MaxLength(1)]
        public byte Accuracy
        {
            get { return _accuracy; }
            set
            {
                SetProperty(ref _accuracy, value);
            }
        }

        // Сила атаки
        private byte _strength;
        [MaxLength(2)]
        public byte Strength
        {
            get { return _strength; }
            set
            {
                SetProperty(ref _strength, value);
            }
        }

        // Пробивание защиты
        private byte _armorPen;
        [MaxLength(1)]
        public byte ArmorPen
        {
            get { return _armorPen; }
            set
            {
                SetProperty(ref _armorPen, value);
            }
        }

        // Урон атаки
        private string _damage = "0";
        [StringLength(10)]
        public string Damage
        {
            get { return _damage; }
            set
            {
                SetProperty(ref _damage, value);
            }
        }
        #endregion
        #region Методы
        public void ResetState()
        {
            Attacks = "0";
            Accuracy = 0;
            Strength = 0;
            ArmorPen = 0;
            Damage = "0";
        }
        #endregion
    }
}
