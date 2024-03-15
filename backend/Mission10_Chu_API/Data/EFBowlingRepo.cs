using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Mission10_Chu_API.Data
{
    // Repository implementation using Entity Framework Core for accessing bowling data
    public class EFBowlingRepo : IBowlingRepo
    {
        private BowlingLeagueContext _context;

        // Constructor to initialize the repository with the specified BowlingLeagueContext
        public EFBowlingRepo(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        // Fetch all bowlers including their associated teams
        public IEnumerable<Bowler> Bowlers => _context.Bowlers.Include(b => b.Team);

        // Fetch all teams
        public IEnumerable<Team> Teams => _context.Teams;

        // Method to fetch bowlers belonging to specified teams
        public IEnumerable<Bowler> GetBowlersByTeam(string[] teamNames)
        {
            return _context.Bowlers
                    .Include(b => b.Team)
                    .Where(b => b.Team != null && teamNames.Contains(b.Team.TeamName))
                    .ToList();
        }
    }
}
