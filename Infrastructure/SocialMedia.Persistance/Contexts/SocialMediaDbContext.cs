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
            builder.Entity<Like>()
        .HasKey(l => l.Id);

            builder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId);

            builder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId);

            builder.Entity<Dislike>()
                .HasKey(d => d.Id);

            builder.Entity<Dislike>()
                .HasOne(d => d.User)
                .WithMany(u => u.Dislikes)
                .HasForeignKey(d => d.UserId);

            builder.Entity<Dislike>()
                .HasOne(d => d.Post)
                .WithMany(p => p.Dislikes)
                .HasForeignKey(d => d.PostId);

            base.OnModelCreating(builder);
        }
    }
}
