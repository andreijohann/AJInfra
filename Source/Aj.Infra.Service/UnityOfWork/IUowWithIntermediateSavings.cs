namespace Aj.Infra.Service.UnityOfWork
{
    /// <summary>
    /// Unit of Work interface with possibility of intermediate saves.
    /// </summary>
    public interface IUowWithIntermediateSavings : IUow
    {
        Task BeginAsync();

        /// <summary>
        /// Saves the changes made so far.
        /// </summary>
        void Save();
        Task SaveAsync();
        Task RollbackAsync();
    }
}
