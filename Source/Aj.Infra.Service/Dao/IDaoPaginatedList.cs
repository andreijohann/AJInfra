using System.Linq.Expressions;

namespace Aj.Infra.Service.Dao
{
    /// <summary>
    /// Paginated list
    /// </summary>
    public interface IDaoPaginatedList
    {

        IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending) where TPersistEnt : class;
        IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
        IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class;
        IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
    }
}
