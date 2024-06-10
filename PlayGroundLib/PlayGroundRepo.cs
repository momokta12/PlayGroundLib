using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGroundLib
{
     public class PlayGroundRepo
    {
        public int nextId = 5;
        private List<PlayGround> PlayGrounds = new()
        {
            new PlayGround { Id = 1, Name = "PlayGround1", MaxChildren = 10, MinAge = 5 },
            new PlayGround { Id = 2, Name = "PlayGround2", MaxChildren = 15, MinAge = 6 },
            new PlayGround { Id = 3, Name = "PlayGround3", MaxChildren = 20, MinAge = 7 },
            new PlayGround { Id = 4, Name = "PlayGround4", MaxChildren = 25, MinAge = 8 }
        };


        public List<PlayGround> GetAllPlayGrounds()
        {
            return new List<PlayGround>(PlayGrounds);
        }

        public PlayGround GetPlayGroundById(int id)
        {
            return PlayGrounds.Find(p => p.Id == id);
        }

        public PlayGround AddPlayGr(PlayGround playGround)
        {
            playGround.Id = nextId++;
            PlayGrounds.Add(playGround);
            return playGround;
        }

        public PlayGround UpdatePlayGround(PlayGround playGround, int id)
        {
            PlayGround? existingplayGround = GetPlayGroundById(id);
            if (existingplayGround is null)
            {
                throw new Exception("PlayGround not found");
            }
            else
            { 

                existingplayGround.Name = playGround.Name;
                existingplayGround.MaxChildren = playGround.MaxChildren;
                existingplayGround.MinAge = playGround.MinAge;
            }
            return existingplayGround;

        }
    }
}
