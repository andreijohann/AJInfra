using Aj.Infra.Service.Dao;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aj.Infra.Data.Dao
{
    /// <summary>
    /// List everything
    /// </summary>
    public class EfDaoList : EfDao, IDaoList
    {
        public EfDaoList(DbContext context) : base(context)
        { }

        public IEnumerable<TPersistEnt> List<TPersistEnt>() where TPersistEnt : class
        {
            return Context.Set<TPersistEnt>().AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>() where TPersistEnt : class
        {
            return await Context.Set<TPersistEnt>().AsNoTracking().ToListAsync();
        }

        public IEnumerable<TPersistEnt> List<TPersistEnt>(params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return EntityWithRelatedProp(Context.Set<TPersistEnt>().AsNoTracking(), relatedProp).ToList();
        }
        public async Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return await EntityWithRelatedProp(Context.Set<TPersistEnt>().AsNoTracking(), relatedProp).ToListAsync();
        }
    }
}
