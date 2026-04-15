using AutoMapper;
using Backend.Contracts.Users;
using Backend.Models;

namespace Backend.Contracts.Posts;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<User, UserSummary>();

        CreateMap<Post, PostResponse>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type))
            .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.SpaceId))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.CommunityName, opt => opt.MapFrom(src => src.Community != null ? src.Community.Name : null))
            .ForMember(dest => dest.CurrentUserVote, opt => opt.Ignore());

        CreateMap<CreatePostRequest, Post>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (PostType)src.Type))
            .ForMember(dest => dest.SpaceId, opt => opt.MapFrom(src => src.TopicId))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Community, opt => opt.Ignore())
            .ForMember(dest => dest.Score, opt => opt.Ignore())
            .ForMember(dest => dest.CommentCount, opt => opt.Ignore())
            .ForMember(dest => dest.Comments, opt => opt.Ignore())
            .ForMember(dest => dest.Votes, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        CreateMap<UpdatePostRequest, Post>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom((src, dest) =>
                src.Type.HasValue ? (PostType)src.Type.Value : dest.Type))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
