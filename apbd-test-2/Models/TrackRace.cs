using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_test_2.Models;

[Table("Track_Race")]
public class TrackRace
{
    [Key] public int TrackRaceId { get; set; }

    [ForeignKey(nameof(Track))] public int TrackId { get; set; }
    public Track Track { get; set; } = null!;
    [ForeignKey(nameof(Race))] public int RaceId { get; set; }
    public Race Race { get; set; } = null!;
    public int Laps { get; set; }
    public int? BestFinishTimeInSeconds { get; set; }

    public ICollection<Participation> Participations { get; set; } = new List<Participation>();
}
