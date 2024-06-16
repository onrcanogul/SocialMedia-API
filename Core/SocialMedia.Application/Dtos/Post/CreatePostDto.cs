using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Dtos
{
    public class CreatePostDto
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
    }
}
