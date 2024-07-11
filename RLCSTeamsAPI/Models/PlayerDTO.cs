namespace RLCSTeamsAPI.Models
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GamerTag { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public int CarPresetId { get; set; }
    }
}
