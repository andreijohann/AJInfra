using Aj.Infra.Service.Dao;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aj.Infra.Data.Dao
{
    public class EfDaoPaginatedList : EfDao, IDaoPaginatedList
    {
        /// <summary>
        /// Paginated list
        /// </summary>
        public EfDaoPaginatedList(DbContext context) : base(context)
        { }

        public IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending) where TPersistEnt : class
        {
            return EntityWithOrder(Context.Set<TPersistEnt>(), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListPageAsync<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending) where TPersistEnt : class
        {
            return await EntityWithOrder(Context.Set<TPersistEnt>(), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return EntityWithRelatedProp(EntityWithOrder(Context.Set<TPersistEnt>(), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines), relatedProp).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListPageAsync<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return await EntityWithRelatedProp(EntityWithOrder(Context.Set<TPersistEnt>(), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines), relatedProp).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class
        {
            return EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListPageAsync<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class
        {
            return await EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return EntityWithRelatedProp(EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines), relatedProp).AsNoTracking().ToList();
        }
        public async Task<IEnumerable<TPersistEnt>> ListPageAsync<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return await EntityWithRelatedProp(EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Skip(start < 1 ? 0 : start - 1).Take(numberOfLines), relatedProp).AsNoTracking().ToListAsync();
        }
    }
}
