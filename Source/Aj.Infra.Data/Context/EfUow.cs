using Aj.Infra.Service.UnityOfWork;

namespace Aj.Infra.Data.Context
{
    public class EfUow<TContext> : IUow where TContext : EfContext
    {
        private bool _disposed;
        protected TContext Context { get; }

        public EfUow(TContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Signals the start of transaction
        /// </summary>
        public virtual void Begin()
        {
            _disposed = false;
        }

        /// <summary>
        /// Saves changes in context (SaveChanges).
        /// </summary>
        public virtual void Commit()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Discards context changes (DiscardChanges).
        /// </summary>
        public virtual void Rollback()
        {
            Context.DiscardChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (!_disposed && disposing)
                {
                    Context.Dispose();
                }

                _disposed = true;
            }
        }



    }
}
