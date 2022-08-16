using System.Linq.Expressions;

namespace Aj.Infra.Service.Dao
{
    /// <summary>
    /// List with selection filter
    /// </summary>
    public interface IDaoListWithFilter
    {
        IEnumerable<TPersistEnt> List<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class;
        Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class;
        IEnumerable<TPersistEnt> List<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
        Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
    }
}
