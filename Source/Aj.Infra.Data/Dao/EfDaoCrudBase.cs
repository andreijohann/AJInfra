using Aj.Infra.Dto;
using Aj.Infra.Service.Dao;
using Microsoft.EntityFrameworkCore;

namespace Aj.Infra.Data.Dao
{
    public class EfDaoCrudBase<TPersistEnt, TId> : EfDao, IDaoCrudBase<TPersistEnt, TId>
        where TPersistEnt : class, IPersistenceEnt<TId>
    {
        public EfDaoCrudBase(DbContext context) : base(context)
        { }

        public virtual void Insert(TPersistEnt entity)
        {
            Context.Set<TPersistEnt>().Add(entity);
        }
        public virtual void Update(TPersistEnt entity)
        {
            var entry = Context.Entry(entity);
            Context.Set<TPersistEnt>().Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TPersistEnt entity)
        {
            Context.Set<TPersistEnt>().Remove(entity);
        }


    }
}
