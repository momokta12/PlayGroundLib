using System.Collections.Generic;
using System.Linq;
using PlayGroundLib;

namespace PlayGroundLib
{
    public class PlayGroundRepositoryDb
    {
        private readonly PlayGroundDbContext _context;

        public PlayGroundRepositoryDb(PlayGroundDbContext context)
        {
            _context = context;
        }

        public List<PlayGround> GetAllPlayGrounds()
        {
            return _context.PlayGrounds.ToList();
        }

        public PlayGround GetPlayGroundById(int id)
        {
            return _context.PlayGrounds.Find(id);
        }

        public PlayGround AddPlayGround(PlayGround playGround)
        {
            _context.PlayGrounds.Add(playGround);
            _context.SaveChanges();
            return playGround;
        }

        public PlayGround UpdatePlayGround(PlayGround playGround, int id)
        {
            var existingPlayGround = _context.PlayGrounds.Find(id);
            if (existingPlayGround is null)
            {
                throw new Exception("PlayGround not found");
            }

            existingPlayGround.Name = playGround.Name;
            existingPlayGround.MaxChildren = playGround.MaxChildren;
            existingPlayGround.MinAge = playGround.MinAge;

            _context.SaveChanges();
            return existingPlayGround;
        }
    }
}
