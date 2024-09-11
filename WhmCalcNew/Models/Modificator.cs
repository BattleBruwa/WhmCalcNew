using System.Text.Json.Serialization;

namespace WhmCalcNew.Models
{
    public class Modificator
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ToolTip { get; set; }

        [JsonIgnore]
        public byte? Condition { get; set; } = null;

        [JsonIgnore]
        public string ModInfo { get => this.ToString(); }

        public override string ToString()
        {
            return $"{Name}: {ToolTip}";
        }
    }
}
