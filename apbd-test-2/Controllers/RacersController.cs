using apbd_test_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_test_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RacersController : ControllerBase
{
    private readonly IDbService _dbService;

    public RacersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    [Route("{racerId}/participations")]
    public async Task<IActionResult> GetRacerParticipations(int racerId)
    {
        try
        {
            var result = await _dbService.GetRacerParticipations(racerId);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}