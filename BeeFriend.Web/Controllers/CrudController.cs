using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers
{

    public abstract class CrudController<TRequest, TResponse, TKey, TService>
        : CustomControllerBase

        where TRequest : class
        where TResponse : class
        where TKey : struct
        where TService : ICrudService<TRequest, TResponse, TKey>

    {
        protected readonly TService _service;

        protected CrudController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TResponse>>> GetAll() 
        {
            var response = await _service.GetAllAsync();

            return ReturnResponse(response, Ok);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TResponse>> GetById(TKey id)
        {
            Result<TResponse> response = await _service.GetByIdAsync(id);

            return ReturnResponse(response, Ok);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TResponse>> Patch(TKey id, TRequest request) 
        {
            Result<TResponse> response = await _service.UpdateAsync(id, request);

            return ReturnResponse(response, Ok);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(TKey id) 
        {
            Result response = await _service.DeleteByIdAsync(id);

            return ReturnResponse(response, NoContent);
        }

        [HttpPost]
        public async Task<ActionResult<TResponse>>Add(TRequest request)
        {
            Result<TResponse> response = await _service.AddAsync(request);

            return ReturnResponse(response, Created);
        }
    }
}
