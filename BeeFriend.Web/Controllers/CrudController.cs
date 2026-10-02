using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.DTO.Interfaces;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers
{

    public abstract class CrudController<TRequest, TResponse, TKey, TService>
        : CustomControllerBase

        where TRequest : class
        where TResponse : class, IResponse<TKey>
        where TKey : struct
        where TService : ICrudService<TRequest, TResponse, TKey>

    {
        protected readonly TService _service;

        protected CrudController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TResponse>>> GetAll(CancellationToken cancellationToken) 
        {
            var response = await _service.GetAllAsync(cancellationToken);

            return ReturnResponse(response, Ok);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TResponse>> GetById(TKey id, CancellationToken cancellationToken)
        {
            Result<TResponse> response = await _service.GetByIdAsync(id, cancellationToken);

            return ReturnResponse(response, Ok);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TResponse>> Patch(TKey id, TRequest request, CancellationToken cancellationToken) 
        {
            Result<TResponse> response = await _service.UpdateAsync(id, request, cancellationToken);

            return ReturnResponse(response, Ok);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(TKey id, CancellationToken cancellationToken) 
        {
            Result response = await _service.DeleteByIdAsync(id, cancellationToken);

            return ReturnResponse(response, NoContent);
        }

        [HttpPost]
        public async Task<ActionResult<TResponse>>Add(TRequest request, CancellationToken cancellationToken)
        {
            Result<TResponse> response = await _service.AddAsync(request, cancellationToken);

            return ReturnResponse(response, value => CreatedAtAction(
                nameof(GetById),
                new {id = value.Id}, 
                value));
        }

    }
}
