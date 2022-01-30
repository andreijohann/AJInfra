using System.Linq.Expressions;

namespace Aj.Infra.Service.Dao
{
    /// <summary>
    /// Paginated list returning total of occurrences
    /// </summary>
    public interface IDaoPaginatedListWithTotal
    {
        IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, out int totalNumOccurrences) where TPersistEnt : class;
        IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, out int totalNumOccurrences, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
        IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter, out int totalNumOccurrences) where TPersistEnt : class;
        IEnumerable<TPersistEnt> ListPage<TPersistEnt, TProprOrd>(int start, int numberOfLines, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, Expression<Func<TPersistEnt, bool>> filter, out int totalNumOccurrences, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
    }
}
