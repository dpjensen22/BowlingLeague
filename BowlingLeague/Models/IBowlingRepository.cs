using System;
using System.Linq;

namespace BowlingLeague.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }

        public void SaveBowler(Bowler b);
        public void DeleteBowler(Bowler b);
        public void CreateBowler(Bowler b);
    }
}
