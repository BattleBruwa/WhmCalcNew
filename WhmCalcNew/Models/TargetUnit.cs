namespace WhmCalcNew.Models
{
    public class TargetUnit
    {
        public string? Faction { get; set; }
        public string? UnitName { get; set; }
        public byte? Thoughness { get; set; }
        public byte? Save { get; set; }
        public byte? Wounds { get; set; }
        public byte? Invuln { get; set; }
        public bool? IsHardToHit { get; set; }
        public bool? IsHardToWound { get; set; }

        public TargetUnit()
        {
            
        }
    }
}
