using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;
using System.Reflection.Emit;

namespace SocialMedia.Persistance.Contexts
{
    public class SocialMediaDbContext : IdentityDbContext
    {
        public SocialMediaDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Dislike> Dislikes { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<PostImageFile> PostImageFiles { get; set; }
        public DbSet<ProfileImageFile> ProfileImageFiles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Friendship>()
            .HasOne(f => f.User1)
            .WithMany(u => u.Friendships)
            .HasForeignKey(f => f.UserId1)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Friendship>()
                .HasOne(f => f.User2)
                .WithMany()
                .HasForeignKey(f => f.UserId2)
                .OnDelete(DeleteBehavior.Restrict);


            

            base.OnModelCreating(builder);
        }
    }
}
