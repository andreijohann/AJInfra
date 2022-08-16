using Aj.Infra.Dto;

namespace Aj.Infra.Service.Services
{
    /// <summary>
    /// Interface for basic CRUD operations in the service layer
    /// </summary>
    /// <typeparam name="TDto">Type of Dto object</typeparam>
    /// <typeparam name="TId">Type of the ID of the object</typeparam>
    public interface IServiceCrud<TDto, TId> where TDto : class
    {
        CreateResultDto<TId> Insert(TDto dto);
        Task<CreateResultDto<TId>> InsertAsync(TDto dto);
        ResultDto Update(TId id, TDto dto);
        Task<ResultDto> UpdateAsync(TId id, TDto dto);
        ResultDto Delete(TId id);
        Task<ResultDto> DeleteAsync(TId id);
        QueryResultDto<TDto> Get(TId id);
        Task<QueryResultDto<TDto>> GetAsync(TId id);
    }
}
