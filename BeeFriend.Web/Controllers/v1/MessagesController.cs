using Asp.Versioning;
using BeeFriend.Core.Application.DTO.MessageDTOs;
using BeeFriend.Core.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]

    public class MessagesController : CustomControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet("{conversationId:guid}")]
        public async Task<ActionResult<IEnumerable<MessageResponse>>> GetMessages(
            Guid conversationId,
            CancellationToken cancellationToken,
            [FromQuery] int page = 1,
            [FromQuery] int limit = 20)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _messageService.GetMessagesByConversationIdAsync(
                conversationId, currentUserId, page, limit, cancellationToken);

            return ReturnResponse(result, Ok);
        }

        [HttpDelete("{messageId:guid}")]
        public async Task<ActionResult> DeleteMessage(
            Guid messageId, 
            CancellationToken cancellationToken)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _messageService.DeleteMessageAsync(
                currentUserId, messageId, cancellationToken);

            return ReturnResponse(result, NoContent);
        }

        [HttpPatch("{messageId:guid}")]
        public async Task<ActionResult<MessageResponse>> Update(
            Guid messageId,
            MessageUpdateRequest request,
            CancellationToken cancellationToken)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _messageService.UpdateAsync(
                currentUserId,
                messageId,
                request,
                cancellationToken);

            return ReturnResponse(result, Ok);
        }
    }
}
