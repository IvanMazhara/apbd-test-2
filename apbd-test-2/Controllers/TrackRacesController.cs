using apbd_test_2.Models.DTOs;
using apbd_test_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_test_2.Controllers;

[ApiController]
[Route("api/track-races")]
public class TrackRacesController : ControllerBase
{
    private readonly IDbService _dbService;

    public TrackRacesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    [Route("/participants")]
    public async Task<IActionResult> AddRacerParticipaion(AddRacerParticipationDto racerParticipationDto)
    {
        throw new NotImplementedException();
        // try
        // {
        //     var result = _dbService.AddNewRaceRacerParticipation(racerParticipationDto);
        // }
    }
}