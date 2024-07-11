namespace RLCSTeamsAPI.Models
{
    public class CoachDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GamerTag { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }
        public string TeamName { get; set; } = string.Empty;
    }
}
