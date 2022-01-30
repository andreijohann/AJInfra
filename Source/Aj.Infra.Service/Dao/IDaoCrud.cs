using Aj.Infra.Dto;
using System;
using System.Linq.Expressions;

namespace Aj.Infra.Service.Dao
{
    /// <summary>
    /// Basic Insert, Update, Delete operations, plus Get. (CRUD)
    /// </summary>
    public interface IDaoCrud<TPersistEnt, TId> : IDaoCrudBase<TPersistEnt, TId>
        where TPersistEnt : class, IPersistenceEnt<TId>
    {
        TPersistEnt GetById(TId id);

        TPersistEnt Get(Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp);
    }
}
