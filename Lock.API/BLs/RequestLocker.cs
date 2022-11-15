using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lock.API.BLs
{
    public class RequestLocker : IRequestLocker
    {

        private static readonly object playersLock = new object();
        HashSet<int> LockedPlayers = new HashSet<int>();

        //release
        public async Task ReleaseRequestAsync(int playerId)
        {
            lock (playersLock)
            {
                LockedPlayers.Remove(playerId);
            }
        }

        //lock
        public async Task LockRequestAsync(int playerId)
        {
            int id ;

            while (true)
            {
                lock (playersLock)
                {
                    id = LockedPlayers.FirstOrDefault(pid => pid == playerId);
                }

                //if player is not locked => out
                if (id == 0)
                    break;

                await Task.Delay(500);
            }

            //lock player
            lock (playersLock)
            {
                LockedPlayers.Add(playerId);
            }
        }
    }
}
