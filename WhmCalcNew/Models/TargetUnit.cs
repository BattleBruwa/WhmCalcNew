namespace WhmCalcNew.Models
{
    public class TargetUnit
    {
        // Фракция цели
        public string? Faction { get; set; }

        // Имя цели
        public string? UnitName { get; set; }

        // Стойкость цели
        public byte? Toughness { get; set; }

        // Защита цели
        public byte? Save { get; set; }

        // Вунды/ХП цели
        public byte? Wounds { get; set; }

        // Инвуль цели
        public byte? Invuln { get; set; }

        // Имеет ли цель -1 на хит
        public bool? IsHardToHit { get; set; }

        // Имеет ли цель -1 на вунд
        public bool? IsHardToWound { get; set; }

        public TargetUnit()
        {
            
        }
    }
}
