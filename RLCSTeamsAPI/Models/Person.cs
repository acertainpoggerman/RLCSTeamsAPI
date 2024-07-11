using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RLCSTeamsAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GamerTag { get; set; } = string.Empty;

        [JsonIgnore]
        public DateOnly DateOfBirth { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        public string Nationality { get; set; } = string.Empty;

        [JsonIgnore]
        public int TeamId { get; set; }
        [JsonIgnore]
        public virtual Team? Team { get; set; }
        public string TeamName => Team != null ? Team.Name : "None" ;
    }
}
