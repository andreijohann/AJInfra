using Aj.Infra.Dto;
using Aj.Infra.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aj.Infra.Presentation.Api.Util
{
    /// <summary>
    /// Utility class with common logic of Controllers methods
    /// </summary>
    public static class ControllerUtil
    {

        #region "get, post, update, delete" 

        public static IActionResult Get<TDto, TId>(TId id, IServiceCrud<TDto, TId> service) where TDto : class
        {
            var result = service.Get(id);
            if (result.IsValid)
                return new OkObjectResult(result.Dto);

            return BuildInvalidResult(result);
        }

        public static async Task<IActionResult> GetAsync<TDto, TId>(TId id, IServiceCrud<TDto, TId> service) where TDto : class
        {
            var result = await service.GetAsync(id);
            if (result.IsValid)
                return new OkObjectResult(result.Dto);

            return BuildInvalidResult(result);
        }

        public static IActionResult GetList<TDto>(ListResultDto<TDto> result)
        {
            if (result.IsValid)
                return new OkObjectResult(result.List);

            return BuildInvalidResult(result);
        }

        public static IActionResult Post<TDto, TId>(TDto dto, IServiceCrud<TDto, TId> service, string action, string apiVersion = "1") where TDto : class
        {

            var result = service.Insert(dto);

            if (result.IsValid)
                return new CreatedAtActionResult(action, controllerName: null, routeValues: new { id = result.IdGenerated, version = apiVersion }, value: dto);

            return BuildInvalidResult(result);
        }

        public static async Task<IActionResult> PostAsync<TDto, TId>(TDto dto, IServiceCrud<TDto, TId> service, string action, string apiVersion = "1") where TDto : class
        {

            var result = await service.InsertAsync(dto);

            if (result.IsValid)
                return new CreatedAtActionResult(action, controllerName: null, routeValues: new { id = result.IdGenerated, version = apiVersion }, value: dto);

            return BuildInvalidResult(result);
        }

        public static IActionResult Put<TDto, TId>(TId id, TDto dto, IServiceCrud<TDto, TId> service) where TDto : class
        {
            var result = service.Update(id, dto);

            if (result.IsValid)
                return new NoContentResult();

            return BuildInvalidResult(result);
        }

        public static async Task<IActionResult> PutAsync<TDto, TId>(TId id, TDto dto, IServiceCrud<TDto, TId> service) where TDto : class
        {
            var result = await service.UpdateAsync(id, dto);

            if (result.IsValid)
                return new NoContentResult();

            return BuildInvalidResult(result);
        }

        public static IActionResult Delete<TDto, TId>(TId id, IServiceCrud<TDto, TId> service) where TDto : class
        {
            var result = service.Delete(id);

            if (result.IsValid)
                return new NoContentResult();

            return BuildInvalidResult(result);
        }

        public static async Task<IActionResult> DeleteAsync<TDto, TId>(TId id, IServiceCrud<TDto, TId> service) where TDto : class
        {
            var result = await service.DeleteAsync(id);

            if (result.IsValid)
                return new NoContentResult();

            return BuildInvalidResult(result);
        }

        #endregion

        #region "Build a result with erros"

        public static IActionResult BuildInvalidResult(ResultDto result)
        {
            if (result.Errors.Any(e => e.GetType() == typeof(UnauthorizedUserDto)))
                return new ForbidResult();

            if (result.Errors.Any(e => e.GetType() == typeof(NonExistentIdDto)))
                return new NotFoundResult();

            var errors = new List<ErrorApiDto>();
            result.Errors.ToList().ForEach(e => errors.Add(new ErrorApiDto() { Message = e.Message, Field = e.Context }));

            return new BadRequestObjectResult(errors);

        }

        #endregion

    }
}