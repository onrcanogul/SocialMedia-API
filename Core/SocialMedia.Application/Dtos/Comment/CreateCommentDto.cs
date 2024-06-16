using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Dtos
{
    public class CreateCommentDto
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Message { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
    }
}
