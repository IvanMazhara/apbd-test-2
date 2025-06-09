using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_test_2.Models;

[Table("Racer")]
public class Racer
{
    [Key] public int RacerId { get; set; }
    [MaxLength(50)] public string FirstName { get; set; } = null!;
    [MaxLength(100)] public string LastName { get; set; } = null!;

    public ICollection<Participation> Participations { get; set; } = new List<Participation>();
}
