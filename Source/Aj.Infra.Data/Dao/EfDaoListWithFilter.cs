using Aj.Infra.Service.Dao;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aj.Infra.Data.Dao
{
    /// <summary>
    /// List with selection filter
    /// </summary>
    public class EfDaoListWithFilter : EfDao, IDaoListWithFilter
    {
        public EfDaoListWithFilter(DbContext context) : base(context)
        { }

        public IEnumerable<TPersistEnt> List<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class
        {
            return EntityWithFilter(filter).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class
        {
            return await EntityWithFilter(filter).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> List<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return EntityWithRelatedProp(EntityWithFilter(filter), relatedProp).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return await EntityWithRelatedProp(EntityWithFilter(filter), relatedProp).AsNoTracking().ToListAsync();
        }
    }
}
