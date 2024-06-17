using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Dtos.LikeDislike
{
    public class UsersLikeDto
    {
        public List<PostDto> Posts { get; set; }
        public int Count { get; set; }
    }
}
