namespace apbd_test_2.Models.DTOs;

public class AddRacerParticipationDto
{
    public String RaceName { get; set; } = null!;
    public String TrackName { get; set; } = null!;
    List<ParticipationDto> Participartions = new List<ParticipationDto>();
}
