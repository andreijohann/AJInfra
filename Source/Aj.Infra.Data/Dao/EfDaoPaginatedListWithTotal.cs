using Aj.Infra.Service.Dao;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aj.Infra.Data.Dao
{
    /// <summary>
    /// Paginated list returning total of occurrences
    /// </summary>
    public class EfDaoPaginatedListWithTotal : EfDao, IDaoPaginatedListWithTotal
    {
        public EfDaoPaginatedListWithTotal(DbContext context) : base(context)
        { }

        public IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, out int totalNumOccurrences) where TPersistEnt : class
        {
            totalNumOccurrences = Context.Set<TPersistEnt>().Count();
            return EntityWithOrder(Context.Set<TPersistEnt>(), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines).AsNoTracking().ToList();
        }

        public IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, out int totalNumOccurrences, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            totalNumOccurrences = Context.Set<TPersistEnt>().Count();
            return EntityWithRelatedProp(EntityWithOrder(Context.Set<TPersistEnt>(), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines), relatedProp).AsNoTracking().ToList();
        }

        public IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter, out int totalNumOccurrences) where TPersistEnt : class
        {
            totalNumOccurrences = EntityWithFilter(filter).Count();
            return EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines).AsNoTracking().ToList();
        }

        public IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter, out int totalNumOccurrences, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            totalNumOccurrences = EntityWithFilter(filter).Count();
            return EntityWithRelatedProp(EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines), relatedProp).AsNoTracking().ToList();
        }
    }
}
