using System.Linq.Expressions;

namespace Aj.Infra.Service.Dao
{
    /// <summary>
    /// List everything
    /// </summary>
    public interface IDaoList
    {
        IEnumerable<TPersistEnt> List<TPersistEnt>() where TPersistEnt : class;
        Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>() where TPersistEnt : class;
        IEnumerable<TPersistEnt> List<TPersistEnt>(params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
        Task<IEnumerable<TPersistEnt>> ListAsync<TPersistEnt>(params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
    }
}
