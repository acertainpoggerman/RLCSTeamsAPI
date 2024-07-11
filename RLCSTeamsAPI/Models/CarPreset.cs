using System.Text.Json.Serialization;

namespace RLCSTeamsAPI.Models
{
    public class CarPreset
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Body { get; set; } = "Octane";
        public string PrimaryColor { get; set; } = "D4";
        public string AccentColor { get; set; } = "A1";
        
        public string Decal { get; set; } = "None";
        public string PaintFinish {  get; set; } = "Glossy";

        public string Wheels { get; set; } = "OEM";
        public string Boost { get; set; } = "Standard";
        public string Trail { get; set; } = "Classic";

        public string Topper { get; set; } = "None";

        [JsonIgnore]
        public virtual List<Player>? Players { get; set; }
    }
}
