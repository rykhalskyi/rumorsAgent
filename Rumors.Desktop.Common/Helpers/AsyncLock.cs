using System;
using System.Threading.Tasks;
using System.Threading;

namespace Rumors.Desktop.Common.Helpers
{
    public class AsyncLock
    {
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public async Task<Releaser> LockAsync()
        {
            await semaphore.WaitAsync();
            return new Releaser(this);
        }

        public struct Releaser : IDisposable
        {
            private readonly AsyncLock toRelease;

            internal Releaser(AsyncLock toRelease)
            {
                this.toRelease = toRelease;
            }

            public void Dispose()
            {
                toRelease?.semaphore.Release();
            }
        }
    }
}
