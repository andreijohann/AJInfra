using System.Linq.Expressions;

namespace Aj.Infra.Service.Dao
{
    /// <summary>
    /// Get the Entity using a filter expression
    /// </summary>
    public interface IDaoGet
    {
        TPersistEnt Get<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class;
        Task<TPersistEnt> GetAsync<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class;
        TPersistEnt Get<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
        Task<TPersistEnt> GetAsync<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
    }
}
