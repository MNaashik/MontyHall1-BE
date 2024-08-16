using Microsoft.AspNetCore.Mvc;

namespace MontyHall1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly MontyHallService _montyHallService;

        public HomeController(MontyHallService montyHallService)
        {
            _montyHallService = montyHallService;
        }

        
        [HttpGet("simulate")]
        public IActionResult Simulate(int numberOfGames, bool switchDoor, int chosenDoor)
        {
            var result = _montyHallService.SimulateGames(numberOfGames, switchDoor, chosenDoor);
            return new JsonResult(result);
        }
    }
}
