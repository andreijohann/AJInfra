using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aj.Infra.Data.Dao
{
    /// <summary>
    /// Base class for Data Access using Entity Framework Core
    /// </summary>
    public class EfDao
    {
        public DbContext Context { get; private set; }
        public EfDao(DbContext context)
        {
            Context = context;
        }

        protected static IOrderedQueryable<TPersistEnt> EntityWithOrder<TPersistEnt, TPropOrder>(IQueryable<TPersistEnt> query, Expression<Func<TPersistEnt, TPropOrder>> propOrder, bool ascending) where TPersistEnt : class
        {
            return ascending
                   ? query.OrderBy(propOrder)
                   : query.OrderByDescending(propOrder);
        }

        protected static IOrderedQueryable<TPersistEnt> EntityWithOrder<TPersistEnt, TPropOrder1, TPropOrder2>(IQueryable<TPersistEnt> query, Expression<Func<TPersistEnt, TPropOrder1>> propOrder1, bool ascending1, Expression<Func<TPersistEnt, TPropOrder2>> propOrder2, bool ascending2) where TPersistEnt : class
        {
            return ascending2
                   ? EntityWithOrder(query, propOrder1, ascending1).ThenBy(propOrder2)
                   : EntityWithOrder(query, propOrder1, ascending1).ThenByDescending(propOrder2);
        }

        protected static IQueryable<TPersistEnt> EntityWithRelatedProp<TPersistEnt>(IQueryable<TPersistEnt> query, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            foreach (var relProp in relatedProp)
            {
                query = query.Include(relProp);
            }
            return query;
        }

        protected IQueryable<TPersistEnt> EntityWithFilter<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class
        {
            if (filter == null)
                return Context.Set<TPersistEnt>().AsQueryable();
            else
                return Context.Set<TPersistEnt>().Where(filter);
        }
    }
}
