using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lock.API.BLs
{
    public class RequestLocker : IRequestLocker
    {
        private static readonly object lockObj = new object();
        private static bool isLock = false;
        private static EventWaitHandle newRequestAvailable = new AutoResetEvent(false);

        //release
        public async Task ReleaseRequest()
        {
            lock (lockObj)
            {
                isLock = false;
            }
            newRequestAvailable.Set();
        }

        //lock
        public async Task LockRequest()
        {
            string id = string.Empty;
            // if it's locked, wait

            if (isLock)
            {
                newRequestAvailable.WaitOne(); // => wait for release
                lock (lockObj)
                {
                    isLock = true;
                }
            }
            else
            {
                lock (lockObj)
                {
                    isLock = true;
                }
            }
        }
    }
}
