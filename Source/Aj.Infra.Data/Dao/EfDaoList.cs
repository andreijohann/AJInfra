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

        public IEnumerable<TPersistEnt> List<TPersistEnt>(params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            return EntityWithRelatedProp(Context.Set<TPersistEnt>().AsNoTracking(), relatedProp).ToList();
        }
    }
}
