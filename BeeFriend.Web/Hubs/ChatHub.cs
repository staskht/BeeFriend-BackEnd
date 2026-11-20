using Azure.Core;
using BeeFriend.Core.Application.DTO.MessageDTOs;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BeeFriend.Web.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;

        public ChatHub(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        public async Task SendMessage(Guid conversationId, MessageCreateRequest messageCreateRequest)
        {
            var currentUserId = Guid.Parse(Context.UserIdentifier!);

            var result = await _messageService.SendAsync(
                currentUserId,
                conversationId,
                messageCreateRequest,
                Context.ConnectionAborted);

            if (result.IsFailure)
                throw new HubException($"Failed to send message with error {result.Error}");

            await Clients.Group(conversationId.ToString())
                .SendAsync("ReceiveMessage", result.Value);
        }

        
    }
}
