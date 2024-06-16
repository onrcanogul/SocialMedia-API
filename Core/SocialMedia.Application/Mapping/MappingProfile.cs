using AutoMapper;
using SocialMedia.Application.Dtos;
using SocialMedia.Application.Dtos.Post;
using SocialMedia.Domain.Entities;
namespace SocialMedia.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //post
            CreateMap<CreatePostDto, Post>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<UpdatePostDto, Post>().ReverseMap();

            //comment
            CreateMap<CreateCommentDto, Comment>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<UpdateCommentDto, Comment>().ReverseMap();

        }
    }
}
