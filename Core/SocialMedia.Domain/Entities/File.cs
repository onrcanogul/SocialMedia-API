using SocialMedia.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Domain.Entities
{
    public class File : BaseEntity
    {
        public string Storage { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
