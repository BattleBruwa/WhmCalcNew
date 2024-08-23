using System.Text.Json.Serialization;

namespace WhmCalcNew.Models
{
    public class Modificator
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ToolTip { get; set; }

        [JsonIgnore]
        public int? Condition { get; set; } = null;
    }
}
