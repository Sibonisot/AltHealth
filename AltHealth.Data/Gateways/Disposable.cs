using System;

namespace AltHealth.Data.Gateways
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        ~Disposable()
        {

        }
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
                DisposeCore();

            _isDisposed = true;

        }

        protected virtual void DisposeCore() { }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
