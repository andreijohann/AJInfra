namespace Aj.Infra.Service.UnityOfWork
{
    /// <summary>
    /// The “Unit Of Work” pattern maintains a list of objects affected by a transaction, coordinates writing changes, and handles potential concurrency issues.
    /// </summary>
    public interface IUow : IDisposable
    {
        /// <summary>
        /// Signals the start of the transaction
        /// </summary>
        void Begin();

        /// <summary>
        /// Saves changes in context (SaveChanges).
        /// </summary>
        void Commit();

        Task CommitAsync();

        /// <summary>
        /// Discards changes in context (DiscardChanges).
        /// </summary>
        void Rollback();

    }
}
