using apbd_test_2.Data;
using apbd_test_2.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace apbd_test_2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<RacerParticipationDto> GetRacerParticipations(int racerId)
    {
        var racer = await _context.Racers
            .Include(r => r.Participations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(tr => tr.Race)
            .Include(r => r.Participations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(tr => tr.Track)
            .FirstOrDefaultAsync(r => r.RacerId == racerId);

        if (racer == null)
            return null;

        var result = new RacerParticipationDto
        {
            RacerId = racer.RacerId,
            FirstName = racer.FirstName,
            LastName = racer.LastName,
            Participations = racer.Participations.Select(p => new ParticipationDto
            {
                Race = new RaceDto
                {
                    Name = p.TrackRace.Race.Name,
                    Location = p.TrackRace.Race.Location,
                    Date = p.TrackRace.Race.Date
                },
                Track = new TrackDto
                {
                    Name = p.TrackRace.Track.Name,
                    LengthInKm = p.TrackRace.Track.LengthInKm
                },
                Laps = p.TrackRace.Laps,
                FinishTimeInSeconds = p.FinishTimeInSeconds,
                Position = p.Position
            }).ToList()
        };

        return result;
    }

    public Task AddNewRaceRacerParticipation(RacerParticipationDto dto)
    {
        throw new NotImplementedException();
    }
}