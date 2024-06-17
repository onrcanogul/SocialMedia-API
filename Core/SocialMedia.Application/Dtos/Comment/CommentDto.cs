using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Dtos
{
    public class CommentDto
    {
        public string Message { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public UserDto User { get; set; }
    }
}
