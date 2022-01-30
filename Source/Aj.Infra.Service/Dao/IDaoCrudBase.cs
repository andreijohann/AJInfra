using Aj.Infra.Dto;

namespace Aj.Infra.Service.Dao
{
    public interface IDaoCrudBase<TPersistEnt, TId>
        where TPersistEnt : class, IPersistenceEnt<TId>
    {
        void Insert(TPersistEnt entity);
        void Update(TPersistEnt entity);
        void Delete(TPersistEnt entity);
    }
}
