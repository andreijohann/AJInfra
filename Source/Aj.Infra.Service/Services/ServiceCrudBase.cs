using Aj.Infra.Dto;
using Aj.Infra.Service.Dao;
using Aj.Infra.Service.UnityOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aj.Infra.Service.Services
{
    /// <summary>
    /// Generic class for basic CRUD operations in the service layer
    /// </summary>
    /// <typeparam name="TDto">Type of Dto object</typeparam>
    /// <typeparam name="TId">Type of the ID of the object</typeparam>
    /// <typeparam name="TPersistEnt">Type of Persistence Entity object</typeparam>
    public class ServiceCrudBase<TDto, TPersistEnt, TId> : IServiceCrud<TDto, TId>
        where TPersistEnt : class, IPersistenceEnt<TId>
        where TDto : class
    {

        private readonly IUow _uow;
        private readonly IDaoCrud<TPersistEnt,TId> _daoCrud;
        private readonly IMapper _mapper;
        public ServiceCrudBase(IUow uow, IDaoCrud<TPersistEnt, TId> daoCrud, IMapper mapper)
        {
            _uow = uow;
            _daoCrud = daoCrud;
            _mapper = mapper;
        }
        public CreateResultDto<TId> Insert(TDto dto)
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

        public ResultDto Update(TId id, TDto dto)
        {
            var result = new ResultDto();

            try
            {
                var ent = _daoCrud.GetById(id);

                if (ent == null) {
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

        public ResultDto Delete(TId id)
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

        public QueryResultDto<TDto> Get(TId id)
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


    }
}
