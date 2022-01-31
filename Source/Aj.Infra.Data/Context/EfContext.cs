using Microsoft.EntityFrameworkCore;

namespace Aj.Infra.Data.Context
{
    /// <summary>
    /// Entity Framework context base class
    /// </summary>
    public class EfContext : DbContext
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContextOptions">Entity Framework Context Settings</param>
        public EfContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        /// <summary>
        /// Undo pending changes
        /// </summary>
        public void DiscardChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}
