using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Repositories
{
    public class ProfileImageFileRepository : Repository<ProfileImageFile>, IProfileImageFileRepository
    {
        public ProfileImageFileRepository(SocialMediaDbContext context) : base(context)
        {
        }
    }
}
