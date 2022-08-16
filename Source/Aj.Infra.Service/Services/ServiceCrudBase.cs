using Aj.Infra.Dto;
using Aj.Infra.Service.Dao;
using Aj.Infra.Service.UnityOfWork;
using AutoMapper;

namespace Aj.Infra.Service.Services
{
    /// <summary>
    /// Generic class for basic CRUD operations in the service layer
    /// </summary>
    /// <typeparam name="TDto">Type of Dto object</typeparam>
    /// <typeparam name="TId">Type of the ID of the object</typeparam>
    /// <typeparam name="TPersistEnt">Type of Persistence Entity object</typeparam>
    public class ServiceCrud<TDto, TPersistEnt, TId> : IServiceCrud<TDto, TId>
        where TPersistEnt : class, IPersistenceEnt<TId>
        where TDto : class
    {

        private readonly IUow _uow;
        private readonly IDaoCrud<TPersistEnt, TId> _daoCrud;
        private readonly IMapper _mapper;
        public ServiceCrud(IUow uow, IDaoCrud<TPersistEnt, TId> daoCrud, IMapper mapper)
        {
            _uow = uow;
            _daoCrud = daoCrud;
            _mapper = mapper;
        }
        public virtual CreateResultDto<TId> Insert(TDto dto)
        {
            var result = new CreateResultDto<TId>();

            try
            {
                _uow.Begin();

                var ent = _mapper.Map<TPersistEnt>(dto);

                _daoCrud.Insert(ent);

                _uow.Commit();

                result.IdGenerated = ent.Id;

            }
            catch (Exception ex)
            {
                result.Errors = new List<ErrorDto> { new ErrorDto { Message = ex.Message } };
            }

            return result;
        }

        public virtual async Task<CreateResultDto<TId>> InsertAsync(TDto dto)
        {
            var result = new CreateResultDto<TId>();

            try
            {
                _uow.Begin();

                var ent = _mapper.Map<TPersistEnt>(dto);

                await _daoCrud.InsertAsync(ent);

                await _uow.CommitAsync();

                result.IdGenerated = ent.Id;

            }
            catch (Exception ex)
            {
                result.Errors = new List<ErrorDto> { new ErrorDto { Message = ex.Message } };
            }

            return result;
        }

        public virtual ResultDto Update(TId id, TDto dto)
        {
            var result = new ResultDto();

            try
            {
                var ent = _daoCrud.GetById(id);

                if (ent == null)
                {
                    result.Errors = new List<ErrorDto> { new NonExistentIdDto() };
                }
                else
                {
                    _uow.Begin();

                    _mapper.Map(dto, ent);
                    _daoCrud.Update(ent);

                    _uow.Commit();
                }

            }
            catch (Exception ex)
            {
                result.Errors = new List<ErrorDto> { new ErrorDto { Message = ex.Message } };
            }

            return result;
        }

        public virtual async Task<ResultDto> UpdateAsync(TId id, TDto dto)
        {
            var result = new ResultDto();

            try
            {
                var ent = await _daoCrud.GetByIdAsync(id);

                if (ent == null)
                {
                    result.Errors = new List<ErrorDto> { new NonExistentIdDto() };
                }
                else
                {
                    _uow.Begin();

                    _mapper.Map(dto, ent);
                    _daoCrud.Update(ent);

                    await _uow.CommitAsync();
                }

            }
            catch (Exception ex)
            {
                result.Errors = new List<ErrorDto> { new ErrorDto { Message = ex.Message } };
            }

            return result;
        }

        public virtual ResultDto Delete(TId id)
        {
            var result = new ResultDto();

            try
            {
                var ent = _daoCrud.GetById(id);

                if (ent == null)
                {
                    result.Errors = new List<ErrorDto> { new NonExistentIdDto() };
                }
                else
                {
                    _uow.Begin();

                    _daoCrud.Delete(ent);

                    _uow.Commit();
                }

            }
            catch (Exception ex)
            {
                result.Errors = new List<ErrorDto> { new ErrorDto { Message = ex.Message } };
            }

            return result;
        }

        public virtual async Task<ResultDto> DeleteAsync(TId id)
        {
            var result = new ResultDto();

            try
            {
                var ent = await _daoCrud.GetByIdAsync(id);

                if (ent == null)
                {
                    result.Errors = new List<ErrorDto> { new NonExistentIdDto() };
                }
                else
                {
                    _uow.Begin();

                    _daoCrud.Delete(ent);

                    await _uow.CommitAsync();
                }

            }
            catch (Exception ex)
            {
                result.Errors = new List<ErrorDto> { new ErrorDto { Message = ex.Message } };
            }

            return result;
        }

        public virtual QueryResultDto<TDto> Get(TId id)
        {
            var result = new QueryResultDto<TDto>();

            try
            {
                var ent = _daoCrud.GetById(id);

                if (ent == null)
                {
                    result.Errors = new List<ErrorDto> { new NonExistentIdDto() };
                }
                else
                {
                    result.Dto = _mapper.Map<TDto>(ent);
                }

            }
            catch (Exception ex)
            {
                result.Errors = new List<ErrorDto> { new ErrorDto { Message = ex.Message } };
            }

            return result;
        }

        public virtual async Task<QueryResultDto<TDto>> GetAsync(TId id)
        {
            var result = new QueryResultDto<TDto>();

            try
            {
                var ent = await _daoCrud.GetByIdAsync(id);

                if (ent == null)
                {
                    result.Errors = new List<ErrorDto> { new NonExistentIdDto() };
                }
                else
                {
                    result.Dto = _mapper.Map<TDto>(ent);
                }

            }
            catch (Exception ex)
            {
                result.Errors = new List<ErrorDto> { new ErrorDto { Message = ex.Message } };
            }

            return result;
        }


    }
}
