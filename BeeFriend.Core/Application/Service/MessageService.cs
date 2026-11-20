using AutoMapper;
using BeeFriend.Core.Application.DTO.MessageDTOs;
using BeeFriend.Core.Application.Helpers;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;

namespace BeeFriend.Core.Application.Service
{
    public class MessageService : IMessageService
    {
        private readonly IConversationService _conversationService;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(
            IConversationService conversationService,
            IMessageRepository messageRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _conversationService = conversationService;
            _messageRepository = messageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<IEnumerable<MessageResponse>>> GetMessagesByConversationIdAsync(
            Guid conversationId, 
            Guid currentUserId, 
            int page, 
            int limit,
            CancellationToken cancellationToken)
        {
            if (page < 1)
                return Errors.Validation(
                    "InvalidPage", "Page must be at least 1.");

            if (limit < 1 || limit > 100)
                return Errors.Validation(
                    "InvalidLimit", "Limit must be between 1 and 100.");

            var userMemberOfConversationResult = await _conversationService.ValidateConversationMembershipAsync(
                currentUserId, conversationId, cancellationToken);

            if (userMemberOfConversationResult.IsFailure)
                return userMemberOfConversationResult.Error!;

            var messages = await _messageRepository.GetMessagesByConversationIdAsync(
                conversationId, page, limit, cancellationToken);

            var messagesResponse = _mapper.Map<List<MessageResponse>>(messages);

            return messagesResponse;

        }

        public async Task<Result> DeleteMessageAsync(
            Guid currentUserId, 
            Guid messageId, 
            CancellationToken cancellationToken)
        {
            var deleted = await _messageRepository.ExecuteDeleteMessageAsync(
                messageId, currentUserId, cancellationToken);

            if (!deleted)
                return Errors.EntityNotFound(
                    "MessageNotFound",
                    "Message not found.");

            return Result.Success();
        }

        public async Task<Result<MessageResponse>> SendAsync(
            Guid currentUserId, 
            Guid conversationId, 
            MessageCreateRequest messageCreateRequest, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(messageCreateRequest);

            bool isValid = DtoValidator.TryValidate(messageCreateRequest, out var errors);

            if (!isValid)
                return Errors.Validation(
                    "InvalidMessageContent",
                    "An Invalid message content.");

            var userMemberOfConversationResult = await _conversationService.ValidateConversationMembershipAsync(
                currentUserId, conversationId, cancellationToken);

            if(userMemberOfConversationResult.IsFailure)
                return userMemberOfConversationResult.Error!;

            var message = Message.Create(conversationId, currentUserId, messageCreateRequest.Content);

            await _messageRepository.AddAsync(message, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<MessageResponse>(message);
        }
    }
}
