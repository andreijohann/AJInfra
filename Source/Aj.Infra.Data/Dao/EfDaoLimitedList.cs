using Aj.Infra.Service.Dao;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aj.Infra.Data.Dao
{
    /// <summary>
    /// List first numberOfLines lines
    /// </summary>
    public class EfDaoLimitedList : EfDao, IDaoLimitedList
    {
        public EfDaoLimitedList(DbContext context) : base(context)
        { }

        public IEnumerable<TPersistEnt> List<TPersistEnt>(int numberOfLines) where TPersistEnt : class
        {
            return Context.Set<TPersistEnt>().Take(numberOfLines).AsNoTracking().ToList();
        }
        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(int numberOfLines) where TPersistEnt : class
        {
            return await Context.Set<TPersistEnt>().Take(numberOfLines).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> List<TPersistEnt>(int numberOfLines, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return EntityWithRelatedProp(Context.Set<TPersistEnt>().Take(numberOfLines), relatedProp).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(int numberOfLines, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return await EntityWithRelatedProp(Context.Set<TPersistEnt>().Take(numberOfLines), relatedProp).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> List<TPersistEnt>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class
        {
            return EntityWithFilter(filter).Take(numberOfLines).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class
        {
            return await EntityWithFilter(filter).Take(numberOfLines).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> List<TPersistEnt>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return EntityWithRelatedProp(EntityWithFilter(filter).Take(numberOfLines), relatedProp).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return await EntityWithRelatedProp(EntityWithFilter(filter).Take(numberOfLines), relatedProp).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> List<TPersistEnt, TProprOrd>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending) where TPersistEnt : class
        {
            return EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Take(numberOfLines).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt, TProprOrd>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending) where TPersistEnt : class
        {
            return await EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Take(numberOfLines).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> List<TPersistEnt, TProprOrd>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return EntityWithRelatedProp(EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Take(numberOfLines), relatedProp).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt, TProprOrd>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return await EntityWithRelatedProp(EntityWithOrder(EntityWithFilter(filter), propOrder, ascending).Take(numberOfLines), relatedProp).AsNoTracking().ToListAsync();
        }
    }
}
