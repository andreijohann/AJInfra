using Aj.Infra.Service.UnityOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Aj.Infra.Data.Context
{
    /// <summary>
    /// Unit of Work with implementation of partial/intermediate saves through Entity Framework transaction support.
    /// </summary>
    public class EfUowWithIntermediateSavings<TContext> : EfUow<TContext>, IUowWithIntermediateSavings where TContext : EfContext
    {
        private bool _disposed;
        private IDbContextTransaction _dbContextTransaction;

        public EfUowWithIntermediateSavings(TContext context) : base(context) { }

        /// <summary>
        /// Signals the start of transaction and open a transaction in the database
        /// </summary>
        public override void Begin()
        {
            base.Begin();
            _disposed = false;
            _dbContextTransaction = ((DbContext)base.Context).Database.BeginTransaction();
        }

        public async Task BeginAsync()
        {
            base.Begin();
            _disposed = false;
            _dbContextTransaction = await ((DbContext)base.Context).Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Saves changes in context (SaveChanges) and Commit the open transaction.
        /// </summary>
        public override void Commit()
        {
            base.Commit();
            _dbContextTransaction.Commit();
        }

        /// <summary>
        /// Saves changes in context (SaveChangesAsync) and Commit the open transaction Async.
        /// </summary>
        public override async Task CommitAsync()
        {
            await base.CommitAsync();
            await _dbContextTransaction.CommitAsync();
        }

        /// <summary>
        /// Discards context changes (DiscardChanges) and Rollback the open transaction.
        /// </summary>
        public override void Rollback()
        {
            base.Rollback();
            _dbContextTransaction.Rollback();
        }

        public async Task RollbackAsync()
        {
            base.Rollback();
            await _dbContextTransaction.RollbackAsync();
        }

        /// <summary>
        /// Saves the changes made so far.
        /// </summary>
        public void Save()
        {
            base.Commit(); // DbContext.SaveChanges()
        }

        public async Task SaveAsync()
        {
            await base.CommitAsync(); // DbContext.SaveChangesAsync()
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_dbContextTransaction != null)
                    _dbContextTransaction.Dispose();
                base.Dispose(disposing);
            }

            _disposed = true;
        }

    }
}
