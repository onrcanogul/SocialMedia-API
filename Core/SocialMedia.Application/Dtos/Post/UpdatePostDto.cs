using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Dtos.Post
{
    public class UpdatePostDto
    {
        public string Title { get; set; } = null!;
        public string Id { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime UpdatedDate { get; } = DateTime.UtcNow;
    }
}
