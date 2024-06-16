using SocialMedia.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IFriendshipService
    {
        Task MakeFriendshipRequestAsync(string user1Id, string user2Id);
        Task AcceptFriendshipRequestAsync(string user1Id, string user2Id);
        Task RejectFriendshipRequestAsync(string user1Id, string user2Id);
        Task<List<UserDto>> GetFriends(string userId);

        Task<List<UserDto>> GetFriendsRequests(string user1Id);

    }
}
