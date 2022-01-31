using Aj.Infra.Service.Dao;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aj.Infra.Data.Dao
{
    /// <summary>
    /// Get the Entity using a filter expression
    /// </summary>
    public class EfDaoGet : EfDao, IDaoGet
    {
        public EfDaoGet(DbContext context) : base(context)
        { }

        public TPersistEnt Get<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class
        {
            IQueryable<TPersistEnt> query = Context.Set<TPersistEnt>().Where(filter);
            return query.AsNoTracking().SingleOrDefault();
        }

        public TPersistEnt Get<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class
        {
            IQueryable<TPersistEnt> query = Context.Set<TPersistEnt>().Where(filter);
            query = EntityWithRelatedProp(query, relatedProp);
            return query.AsNoTracking().SingleOrDefault();
        }


    }
}
