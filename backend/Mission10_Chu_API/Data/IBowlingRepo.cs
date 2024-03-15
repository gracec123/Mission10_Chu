namespace Mission10_Chu_API.Data
{
    // Interface for the repository handling bowling data
    public interface IBowlingRepo
    {
        // Collection of all bowlers
        IEnumerable<Bowler> Bowlers { get; }

        // Collection of all teams
        IEnumerable<Team> Teams { get; }

        // Method to retrieve bowlers belonging to specified teams
        IEnumerable<Bowler> GetBowlersByTeam(string[] teamNames);
    }
}
