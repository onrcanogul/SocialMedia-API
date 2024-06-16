using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Abstractions.UnitOfWork;
using SocialMedia.Application.Dtos;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Persistance.Services
{
    public class FriendshipService(IFriendshipRepository repository, IUnitOfWork unitOfWork) : IFriendshipService
    {
        public async Task AcceptFriendshipRequestAsync(string user1Id, string user2Id)
        {
            Friendship? friendship = await repository.Table.FirstOrDefaultAsync(x => x.UserId1 == user1Id && x.UserId2 == user2Id)!;
            friendship.Status = Domain.Enums.FriendshipStatus.Accepted;
            await unitOfWork.CommitAsync();
        }

        public async Task<List<UserDto>> GetFriends(string userId)
        {
           List<UserDto> users = await repository.Table
                .Include(x => x.User1)
                .Include(x => x.User2)
                .Where(x => x.UserId1 == userId && x.Status == Domain.Enums.FriendshipStatus.Accepted)
                .Select(x => new UserDto
                {
                    Name = x.User2.Name,
                    Surname = x.User2.Surname,
                    
                }).ToListAsync();

            return users;
        }

        public async Task<List<UserDto>> GetFriendsRequests(string userId)
        {
            List<UserDto> users = await repository.Table
                .Include(x => x.User1)
                .Include(x => x.User2)
                .Where(x => x.UserId2 == userId && x.Status == Domain.Enums.FriendshipStatus.Pending)
                .Select(x => new UserDto
                {
                    Name = x.User1.Name,
                    Surname = x.User1.Surname

                }).ToListAsync();

            return users;
        }

        public async Task MakeFriendshipRequestAsync(string user1Id, string user2Id)
        {
            Friendship friendship = new()
            {
                UserId1 = user1Id,
                UserId2 = user2Id,
                CreatedDate = DateTime.UtcNow,
                Status = Domain.Enums.FriendshipStatus.Pending
            };

            await repository.AddAsync(friendship);
            await unitOfWork.CommitAsync();
        }

        public async Task RejectFriendshipRequestAsync(string user1Id, string user2Id)
        {
            Friendship? friendship = await repository.Table.FirstOrDefaultAsync(x => x.UserId1 == user1Id && x.UserId2 == user2Id);
            friendship.Status = Domain.Enums.FriendshipStatus.Rejected;
            await unitOfWork.CommitAsync();
        }
    }
}
