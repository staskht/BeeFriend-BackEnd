using BeeFriend.Core.Application.DTO.ConversationDTOs;
using BeeFriend.Core.Application.Helpers;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters;
using BeeFriend.Core.Domain.UnitOfWorkContract;


namespace BeeFriend.Core.Application.Service
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserProfilesService _userProfilesService;
        private readonly IConversationUserRepository _conversationUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConversationService
            (IConversationRepository conversationRepository, 
            IGetAllByIdsRepository<UserProfile, Guid> getAllByIdsRepository,
            IUserProfilesService userProfilesService,
            IUnitOfWork unitOfWork,
            IConversationUserRepository conversationUserRepository)
        {
            _conversationRepository = conversationRepository;
            _userProfilesService = userProfilesService;
            _unitOfWork = unitOfWork;
            _conversationUserRepository = conversationUserRepository;
        }



        public async Task<Result<Guid>> CreateAsync(
            Guid currentUserId, 
            ConversationCreateRequest conversationCreateRequest, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(conversationCreateRequest);

            if (currentUserId == Guid.Empty)
                return Errors.Validation("EmptyGuidUserId", "Invalid user id.");

            var conversationMembers = new HashSet<Guid>(conversationCreateRequest.Members);
            conversationMembers!.Add(currentUserId);

            if (conversationMembers.Count < 2)
                return Errors.Validation(
                    "InsufficientMembers",
                    "A conversation must have at least two distinct members.");

            var usersExist = await _userProfilesService.ExistsAsync(conversationMembers, cancellationToken);

            if (usersExist.IsFailure)
                return usersExist.Error!;

            var members = conversationMembers
                .Select(userId => new ConversationUser
                {
                    UserId = userId,
                })
                .ToList();

            var conversation = Conversation.Create(members);

            await _conversationRepository.AddAsync(conversation, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return conversation.Id;

        }


        public async Task<Result> AddMembersAsync(
            Guid currentUserId,
            Guid conversationId,
            ConversationAddRequest conversationAddRequest, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(conversationAddRequest);

            var validationResult = await ValidateConversationMembershipAsync(
                currentUserId, conversationId, cancellationToken);

            if (validationResult.IsFailure)
                return validationResult.Error!;

            var usersExist = await _userProfilesService.ExistsAsync(conversationAddRequest.Members, cancellationToken);

            if (usersExist.IsFailure)
                return usersExist.Error!;

            var areUsersMembersOfConversation = await _conversationRepository.AreUsersMembersOfConversationAsync(
                conversationAddRequest.Members, conversationId, cancellationToken);

            if (areUsersMembersOfConversation)
                return Errors.Conflict("ConversationContainsOneOrMoreUsers", "One or more users already in conversaton.");

            foreach (var memberId in conversationAddRequest.Members)
            {
                var member = new ConversationUser
                {
                    ConversationId = conversationId,
                    UserId = memberId,
                };

                _conversationUserRepository.Add(member);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();

        }

        public async Task<Result> LeaveConversationAsync(
            Guid currentUserId, 
            Guid conversationId,
            CancellationToken cancellationToken)
        {

            var validationResult = await ValidateConversationMembershipAsync(
                currentUserId, conversationId, cancellationToken);

            if (validationResult.IsFailure)
                return validationResult.Error!;

            var memberToRemove = new ConversationUser
            {
                ConversationId = conversationId,
                UserId = currentUserId,
            };

            _conversationUserRepository.Delete(memberToRemove);

            var conversationMembersCount = 
                await _conversationUserRepository.ConversationMembersCount(conversationId);

            if (conversationMembersCount == 0)
            {
                var conversation = Conversation.CreateStub(conversationId);

                _conversationRepository.Delete(conversation);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result<IEnumerable<ConversationSummaryDto>>> GetUsersConversationsSummariesAsync(
            Guid userId, 
            CancellationToken cancellationToken)
        {
            var userExistsResult = await _userProfilesService.ExistsAsync([userId], cancellationToken);

            if (userExistsResult.IsFailure)
                return userExistsResult.Error!; 

            var conversationSummaries = 
                await _conversationRepository.GetUsersConversationsSummariesAsync(userId, cancellationToken);

            return (Result<IEnumerable<ConversationSummaryDto>>)conversationSummaries;
        }

        private async Task<Result> ValidateConversationMembershipAsync(Guid currentUserId, Guid conversationId, CancellationToken cancellationToken)
        {
            if (currentUserId == Guid.Empty)
                return Errors.Validation(
                    "EmptyGuidUserId", 
                    "Invalid user id.");

            var result = await _conversationRepository
                .IsUserMemberOfConversationAsync(
                currentUserId, 
                conversationId, 
                cancellationToken);

            if (!result)
                return Errors.EntityNotFound(
                    "ConversationNotFound", 
                    "Conversation was not found.");

            return Result.Success();
        }

    }
}
