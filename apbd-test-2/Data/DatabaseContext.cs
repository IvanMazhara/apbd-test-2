using apbd_test_2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_test_2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<Participation> Participations { get; set; }

    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Racer>().HasData(
            new Racer { RacerId = 1, FirstName = "Lewis", LastName = "Hamilton" },
            new Racer { RacerId = 2, FirstName = "Max", LastName = "Verstappen" }
        );
        
        modelBuilder.Entity<Track>().HasData(
            new Track { TrackId = 1, Name = "Silverstone Circuit", LengthInKm = 5.89m },
            new Track { TrackId = 2, Name = "Monaco Circuit", LengthInKm = 3.34m }
        );
        
        modelBuilder.Entity<Race>().HasData(
            new Race { RaceId = 1, Name = "British Grand Prix", Location = "Silverstone, UK", Date = new DateTime(2025, 7, 14) },
            new Race { RaceId = 2, Name = "Monaco Grand Prix", Location = "Monte Carlo, Monaco", Date = new DateTime(2025, 5, 25) }
        );
        
        modelBuilder.Entity<TrackRace>().HasData(
            new TrackRace { TrackRaceId = 1, TrackId = 1, RaceId = 1, Laps = 100, BestFinishTimeInSeconds = 5460 },
            new TrackRace { TrackRaceId = 2, TrackId = 2, RaceId = 2, Laps = 123, BestFinishTimeInSeconds = 6300 }
        );
        
        modelBuilder.Entity<Participation>().HasData(
            new Participation
            {
                RacerId = 1,
                TrackRaceId = 1,
                FinishTimeInSeconds = 5460,
                Position = 1
            },
            new Participation
            {
                RacerId = 1,
                TrackRaceId = 2,
                FinishTimeInSeconds = 6300,
                Position = 2
            }
        );
    }
}