using Microsoft.EntityFrameworkCore;

namespace RLCSTeamsAPI.Models
{
    public class RlcsContext : DbContext
    {
        public RlcsContext(DbContextOptions<RlcsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 3 Players in a Team
            modelBuilder.Entity<Team>()
                .HasMany(team => team.Players)
                .WithOne(player => player.Team)
                .HasForeignKey(player => player.TeamId);

            // A Team has 1 Coach
            modelBuilder.Entity<Team>()
                .HasOne(team => team.Coach)
                .WithOne(coach => coach.Team)
                .HasForeignKey<Coach>(coach => coach.TeamId);

            // A Player has 1 Preset, A Preset can be used by many Players
            modelBuilder.Entity<CarPreset>()
                .HasMany(preset => preset.Players)
                .WithOne(player => player.CarPreset)
                .HasForeignKey(player => player.CarPresetId);

            modelBuilder.Seed();
        }

        public DbSet<CarPreset> CarPresets { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }

    }
}
