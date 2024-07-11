using System.Text.Json.Serialization;

namespace RLCSTeamsAPI.Models
{
    public class Player : Person
    {
        [JsonIgnore]
        public int CarPresetId { get; set; }

        [JsonPropertyOrder(1)]
        public virtual CarPreset? CarPreset { get; set; }
    }
}
