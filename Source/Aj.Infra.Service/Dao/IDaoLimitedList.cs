using System.Linq.Expressions;

namespace Aj.Infra.Service.Dao
{
    /// <summary>
    /// List first numberOfLines lines
    /// </summary>
    public interface IDaoLimitedList
    {
        IEnumerable<TPersistEnt> List<TPersistEnt>(int numberOfLines) where TPersistEnt : class;
        IEnumerable<TPersistEnt> List<TPersistEnt>(int numberOfLines, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
        IEnumerable<TPersistEnt> List<TPersistEnt>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter) where TPersistEnt : class;
        IEnumerable<TPersistEnt> List<TPersistEnt>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
        IEnumerable<TPersistEnt> List<TPersistEnt, TProprOrd>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter, Expression<Func<TPersistEnt,TProprOrd>> propOrder, bool ascending) where TPersistEnt : class;
        IEnumerable<TPersistEnt> List<TPersistEnt, TProprOrd>(int numberOfLines, Expression<Func<TPersistEnt, bool>> filter, Expression<Func<TPersistEnt, TProprOrd>> propOrder, bool ascending, params Expression<Func<TPersistEnt, object>>[] relatedProp) where TPersistEnt : class;
    }
}
