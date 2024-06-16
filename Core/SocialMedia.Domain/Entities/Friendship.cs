using SocialMedia.Domain.Entities.Base;
using SocialMedia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Friendship : BaseEntity
    {
        public string UserId1 { get; set; } = null!;
        public string UserId2 { get; set; } = null!;
        public FriendshipStatus Status { get; set; } = FriendshipStatus.Pending;
        public virtual AppUser User1 { get; set; }
        public virtual AppUser User2 { get; set; }

        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }

    }
}
