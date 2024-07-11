namespace RLCSTeamsAPI.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;

        public virtual Coach? Coach {  get; set; }

        public virtual List<Player> Players { get; set; } = new List<Player>();
    }
}
