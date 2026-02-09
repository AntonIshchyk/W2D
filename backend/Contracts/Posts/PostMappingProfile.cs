using AutoMapper;
using Backend.Models;

namespace Backend.Contracts.Posts;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        // Post -> PostResponse
        CreateMap<Post, PostResponse>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))
            .ForMember(dest => dest.ActivityTitle, opt => opt.MapFrom(src => src.Activity != null ? src.Activity.Title : null))
            .ForMember(dest => dest.CurrentUserVote, opt => opt.Ignore()); // Set manually in service

        // CreatePostRequest -> Post
        CreateMap<CreatePostRequest, Post>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (PostType)src.Type))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Activity, opt => opt.Ignore())
            .ForMember(dest => dest.Score, opt => opt.Ignore())
            .ForMember(dest => dest.CommentCount, opt => opt.Ignore())
            .ForMember(dest => dest.Comments, opt => opt.Ignore())
            .ForMember(dest => dest.Votes, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        // UpdatePostRequest -> Post (for updating existing entity)
        CreateMap<UpdatePostRequest, Post>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom((src, dest) =>
                src.Type.HasValue ? (PostType)src.Type.Value : dest.Type))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
