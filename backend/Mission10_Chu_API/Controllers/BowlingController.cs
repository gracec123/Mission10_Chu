using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10_Chu_API.Data;
using System.Linq;

namespace Mission10_Chu_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private IBowlingRepo _bowlingRepo;

        // Constructor to initialize the controller with the specified IBowlingRepo implementation
        public BowlingController(IBowlingRepo temp)
        {
            _bowlingRepo = temp;
        }

        // Endpoint: /bowling
        // HTTP GET method to retrieve bowlers grouped by teams
        [HttpGet]
        public ActionResult<IEnumerable<Bowler>> GetBowlersByTeams()
        {
            // Array of team names to filter bowlers
            string[] teamNames = { "Marlins", "Sharks" };

            // Retrieve bowlers from the repository and map them to anonymous objects for response
            var bowlers = _bowlingRepo.GetBowlersByTeam(teamNames)
                .Select(b => new
                {
                    b.BowlerId,
                    BowlerName = $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}",
                    b.BowlerAddress,
                    b.BowlerCity,
                    b.BowlerState,
                    b.BowlerZip,
                    b.BowlerPhoneNumber,
                    TeamName = b.Team?.TeamName // Safely access TeamName, considering Team could be null
                });

            if (!bowlers.Any())
            {
                return NotFound("No bowlers found for the specified teams.");
            }

            return Ok(bowlers);
        }

    }
}


