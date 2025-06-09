using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_test_2.Models;

[PrimaryKey(nameof(RacerId), nameof(TrackRaceId))]
[Table("Participation")]
public class Participation
{
    [ForeignKey(nameof(Racer))] public int RacerId { get; set; }
    public Racer Racer { get; set; } = null!;

    [ForeignKey(nameof(TrackRace))] public int TrackRaceId { get; set; }
    public TrackRace TrackRace { get; set; } = null!;
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}
