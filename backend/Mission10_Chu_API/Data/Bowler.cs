using System;
using System.Collections.Generic;

namespace Mission10_Chu_API.Data;


// Partial class representing a Bowler entity
public partial class Bowler
{
    // Unique identifier for the bowler
    public int BowlerId { get; set; }

    public string? BowlerLastName { get; set; }

    public string? BowlerFirstName { get; set; }

    public string? BowlerMiddleInit { get; set; }

    public string? BowlerAddress { get; set; }

    public string? BowlerCity { get; set; }

    public string? BowlerState { get; set; }

    public string? BowlerZip { get; set; }

    public string? BowlerPhoneNumber { get; set; }

    public int? TeamId { get; set; }

    public virtual ICollection<BowlerScore> BowlerScores { get; set; } = new List<BowlerScore>();

    public virtual Team? Team { get; set; }
}
