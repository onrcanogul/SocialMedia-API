using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Dtos.LikeDislike
{
    public class LikeDto
    {
        public List<UserDto> Users { get; set; }
        public int Count { get; set; }
    }
}
