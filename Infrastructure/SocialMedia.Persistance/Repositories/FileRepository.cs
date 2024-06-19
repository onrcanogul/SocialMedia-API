using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Repositories
{
    public class FileRepository : Repository<Domain.Entities.File>, IFileRepository
    {
        public FileRepository(SocialMediaDbContext context) : base(context)
        {
        }
    }
}
