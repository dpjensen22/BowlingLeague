using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeague.Models
{
    public class EFBowlingRepository : IBowlingRepository

    {
        private BowlingLeagueDbContext _context { get; set; }
        public EFBowlingRepository(BowlingLeagueDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;


        public void SaveBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }

        public void CreateBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }
    }

}
