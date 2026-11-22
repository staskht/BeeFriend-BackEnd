using Asp.Versioning;
using BeeFriend.Core.Application.DTO.ConversationDTOs;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ConversationController : CustomControllerBase
    {
        private readonly IConversationService _conversationService;

        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }


        [HttpGet("{conversationId:guid}")]
        public async Task<ActionResult<ConversationDetailResponse>> GetById(Guid conversationId, CancellationToken cancellationToken)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _conversationService.GetByIdAsync(conversationId, currentUserId, cancellationToken);

            return ReturnResponse(result, Ok);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] ConversationCreateRequest conversationCreateRequest, 
            CancellationToken cancellationToken)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);


            var result = await _conversationService.CreateAsync(currentUserId, conversationCreateRequest, cancellationToken);

            return ReturnResponse(result, () =>
                    CreatedAtAction(
                        nameof(GetById),
                        new { conversationId = result.Value },
                        null));
        }

        [HttpPost("{conversationId:guid}")]
        public async Task<ActionResult> AddMembers(
            Guid conversationId,
            [FromBody] ConversationAddRequest conversationAddRequest,
            CancellationToken cancellationToken)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _conversationService.AddMembersAsync(currentUserId, conversationId, conversationAddRequest, cancellationToken);

            return ReturnResponse(result, Ok);
        }

        [HttpGet("summaries")]
        public async Task<ActionResult<ConversationDetailResponse>> GetUsersConversationsSummaries(
            CancellationToken cancellationToken) 
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _conversationService.GetUsersConversationsSummariesAsync(currentUserId, cancellationToken);

            return ReturnResponse(result, Ok);
        }

        [HttpGet("leave/{conversationId:guid}")]
        public async Task<ActionResult> LeaveConversation(
            Guid conversationId, 
            CancellationToken cancellationToken)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _conversationService.LeaveConversationAsync(currentUserId, conversationId, cancellationToken);

            return ReturnResponse(result, NoContent);
        }
    }
}
