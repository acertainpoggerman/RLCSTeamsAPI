using Microsoft.EntityFrameworkCore;

namespace RLCSTeamsAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarPreset>().HasData(
                // Stocktane
                new CarPreset { 
                    Id = 1 
                },
                // French Fennec
                new CarPreset { 
                    Id = 2, 
                    Body = "Fennec", 
                    PrimaryColor = "C4", 
                    AccentColor = "N2", 
                    PaintFinish = "Anodized Pearl", 
                    Wheels = "Cristiano", 
                    Boost = "Gold Rush", 
                    Trail = "Luminous" 
                },
                // Black Bluster Bar Fennec
                new CarPreset { 
                    Id = 3, 
                    Body = "Fennec", 
                    PrimaryColor = "H7", 
                    AccentColor = "A7",
                    Decal = "Bluster Bar",
                    PaintFinish = "Anodized Pearl", 
                    Wheels = "Dieci (Black)", 
                    Boost = "Gold Rush", 
                    Trail = "Luminous" 
                },
                // KC 2024 Fennec
                new CarPreset { 
                    Id = 4, 
                    Body = "Fennec",
                    Decal = "Karmine Corp (2024)", 
                    Wheels = "OEM (Black)",
                    Boost = "Gold Rush", 
                    Trail = "Luminous" 
                },
                // M8 2024 Fennec
                new CarPreset { 
                    Id = 5, 
                    Body = "Fennec",
                    Decal = "M8 Alpine (2024)", 
                    Wheels = "OEM (Black)",
                    Boost = "Gold Rush", 
                    Trail = "Luminous" 
                },
                // Kiwi Fennec
                new CarPreset { 
                    Id = 6, 
                    Body = "Fennec (Gold)",
                    PrimaryColor = "E3",
                    AccentColor = "G4",
                    PaintFinish = "Pearlescent",
                    Wheels = "Kiwi",
                    Boost = "Gold Rush"
                }
            );

            modelBuilder.Entity<Player>().HasData(
                // Karmine Corp
                new Player { Id = 1, Name = "Axel Touret", GamerTag = "Vatira", DateOfBirth = DateOnly.Parse("2006-05-19"), Nationality = "France", TeamId = 1, CarPresetId = 3 },
                new Player { Id = 2, Name = "Tristan Soyez", GamerTag = "Atow.", DateOfBirth = DateOnly.Parse("2007-02-22"), Nationality = "Belgium", TeamId = 1, CarPresetId = 4 },
                new Player { Id = 3, Name = "Finlay Ferguson", GamerTag = "rise.", DateOfBirth = DateOnly.Parse("2004-09-05"), Nationality = "England", TeamId = 1, CarPresetId = 1 },
                // Team Vitality
                new Player { Id = 4, Name = "Yanis Champenois", GamerTag = "Alpha54", DateOfBirth = DateOnly.Parse("2003-06-27"), Nationality = "France", TeamId = 2, CarPresetId = 3 },
                new Player { Id = 5, Name = "Andrea Radovanovic", GamerTag = "Radosin", DateOfBirth = DateOnly.Parse("2004-01-12"), Nationality = "France", TeamId = 2, CarPresetId = 3 },
                new Player { Id = 6, Name = "Alexis Bernier", GamerTag = "zen", DateOfBirth = DateOnly.Parse("2007-02-20"), Nationality = "France", TeamId = 2, CarPresetId = 2 },
                // G2 Stride
                new Player { Id = 7, Name = "Massimo Franceschi", GamerTag = "Atomic", DateOfBirth = DateOnly.Parse("2003-08-12"), Nationality = "United States", TeamId = 3, CarPresetId = 1 },
                new Player { Id = 8, Name = "Landon Konerman", GamerTag = "BeastMode", DateOfBirth = DateOnly.Parse("2005-08-03"), Nationality = "United States", TeamId = 3, CarPresetId = 1 },
                new Player { Id = 9, Name = "Daniel Piecenski", GamerTag = "Daniel", DateOfBirth = DateOnly.Parse("2006-12-05"), Nationality = "United States", TeamId = 3, CarPresetId = 2 },
                // Team Falcons
                new Player { Id = 10, Name = "Mohammed Alotaibi", GamerTag = "trk511", DateOfBirth = DateOnly.Parse("2005-07-26"), Nationality = "Saudi Arabia", TeamId = 4, CarPresetId = 2 },
                new Player { Id = 11, Name = "Saleh Bakhashwin", GamerTag = "Rw9", DateOfBirth = DateOnly.Parse("2007-06-10"), Nationality = "Saudi Arabia", TeamId = 4, CarPresetId = 2 },
                new Player { Id = 12, Name = "Yazid Bakhashwin", GamerTag = "Kiileerrz", DateOfBirth = DateOnly.Parse("2007-06-10"), Nationality = "Saudi Arabia", TeamId = 4, CarPresetId = 2 },
                // FURIA Esports
                new Player { Id = 13, Name = "Yan Xisto Nolasco", GamerTag = "yanxnz", DateOfBirth = DateOnly.Parse("2004-08-10"), Nationality = "Brazil", TeamId = 5, CarPresetId = 2 },
                new Player { Id = 14, Name = "Gabriel Buzon", GamerTag = "Lostt", DateOfBirth = DateOnly.Parse("2005-03-29"), Nationality = "Brazil", TeamId = 5, CarPresetId = 2 },
                new Player { Id = 15, Name = "Arthur Langsch Miguel", GamerTag = "drufinho", DateOfBirth = DateOnly.Parse("2005-06-26"), Nationality = "Brazil", TeamId = 5, CarPresetId = 3 },
                // Gentle Mates Alpine
                new Player { Id = 16, Name = "Amine Benayachi", GamerTag = "Itachi", DateOfBirth = DateOnly.Parse("2003-08-13"), Nationality = "Morocco", TeamId = 6, CarPresetId = 5 },
                new Player { Id = 17, Name = "Enzo Grondein", GamerTag = "Seikoo", DateOfBirth = DateOnly.Parse("2004-06-07"), Nationality = "France", TeamId = 6, CarPresetId = 6 },
                new Player { Id = 18, Name = "Charles Sabiani", GamerTag = "drufinho", DateOfBirth = DateOnly.Parse("2005-03-05"), Nationality = "France", TeamId = 6, CarPresetId = 2 }
            );
            
            modelBuilder.Entity<Coach>().HasData(
                new Coach { Id = 1, Name = "Victor Francal", GamerTag = "Ferra", DateOfBirth = DateOnly.Parse("1996-10-31"), Nationality = "France", TeamId = 1 },
                new Coach { Id = 2, Name = "Victor Locquet", GamerTag = "Fairy Peak!", DateOfBirth = DateOnly.Parse("1998-05-26"), Nationality = "France", TeamId = 2 },
                new Coach { Id = 3, Name = "Matthew Ackerman", GamerTag = "Satthew", DateOfBirth = DateOnly.Parse("1999-04-29"), Nationality = "United States", TeamId = 3 },
                new Coach { Id = 4, Name = "Abdulrahman Saad", GamerTag = "d7oom-24", DateOfBirth = DateOnly.Parse("2003-08-03"), Nationality = "Saudi Arabia", TeamId = 4 },
                new Coach { Id = 5, Name = "Mateus Santos", GamerTag = "STL", DateOfBirth = DateOnly.Parse("1999-07-24"), Nationality = "Brazil", TeamId = 5 },
                new Coach { Id = 6, Name = "Benjamin Wagner", GamerTag = "Eversax", DateOfBirth = DateOnly.Parse("1996-06-24"), Nationality = "Belgium", TeamId = 6 }
            );

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Karmine Corp", Region = "EU" },
                new Team { Id = 2, Name = "Team Vitality", Region = "EU" },
                new Team { Id = 3, Name = "G2 Stride", Region = "NA" },
                new Team { Id = 4, Name = "Team Falcons", Region = "MENA" },
                new Team { Id = 5, Name = "FURIA Esports", Region = "SAM" },
                new Team { Id = 6, Name = "Gentle Mates Alpine", Region = "EU" }
            );
        }
    }
}
