using apbd_test_2.Models.DTOs;

namespace apbd_test_2.Services;

public interface IDbService
{
    public Task<RacerParticipationDto> GetRacerParticipations(int racerId);
    public Task AddNewRaceRacerParticipation(RacerParticipationDto dto);
}