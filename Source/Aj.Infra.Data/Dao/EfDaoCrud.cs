using Aj.Infra.Dto;
using Aj.Infra.Service.Dao;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aj.Infra.Data.Dao
{
    public class EfDaoCrud<TPersistEnt, TId> : EfDaoCrudBase<TPersistEnt, TId>, IDaoCrud<TPersistEnt, TId>
        where TPersistEnt : class, IPersistenceEnt<TId>
    {
        public EfDaoCrud(DbContext context) : base(context)
        { }

        public TPersistEnt GetById(TId id)
        {
            TPersistEnt ent;
            var t = typeof(TId);
            if (t.IsValueType) { 
                ent = Context.Set<TPersistEnt>().Find(id);
            } 
            else 
            {
                ent = Context.Set<TPersistEnt>().Find(t.GetProperties().Select(p => p.GetValue(id)).ToArray());
            }
            return ent;
        }

        public TPersistEnt Get(Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp)
        {
            IQueryable<TPersistEnt> query = Context.Set<TPersistEnt>().Where(filter);
            query = EntityWithRelatedProp(query, relatedProp);
            return query.SingleOrDefault();
        }


    }
}
