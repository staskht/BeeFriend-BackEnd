using Azure.Core;
using BeeFriend.Core.Application.DTO.MessageDTOs;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BeeFriend.Web.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        private readonly IConversationService _conversationService;

        public ChatHub(
            IMessageService messageService,
            IConversationService conversationService)
        {
            _messageService = messageService;
            _conversationService = conversationService;
        }

        public async Task JoinConversation(Guid conversationId)
        {
            var currentUserId = GetCurrentUserId();

            var result = await _conversationService
                .ValidateConversationMembershipAsync(currentUserId, conversationId, Context.ConnectionAborted);

            if (result.IsFailure)
                throw new HubException($"Unable to join conversation");

            await Groups.AddToGroupAsync(
                Context.ConnectionId, conversationId.ToString(), Context.ConnectionAborted);
        }

        public async Task LeaveConversation(Guid conversationId)
        {

            await Groups.RemoveFromGroupAsync(
                Context.ConnectionId, conversationId.ToString(), Context.ConnectionAborted);
        }
        
        public async Task SendMessage(Guid conversationId, MessageCreateRequest messageCreateRequest)
        {
            var currentUserId = GetCurrentUserId();

            var result = await _messageService.SendAsync(
                currentUserId,
                conversationId,
                messageCreateRequest,
                Context.ConnectionAborted);

            if (result.IsFailure)
                throw new HubException($"Unable to send message.");

            await Clients.Group(conversationId.ToString())
                .SendAsync("ReceiveMessage", result.Value, Context.ConnectionAborted);
        }

        private Guid GetCurrentUserId()
        {
            if (!Guid.TryParse(Context.UserIdentifier, out var userId))
                throw new HubException("Invalid user identifier.");

            return userId;
        }


    }
}
