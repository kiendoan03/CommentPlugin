using AutoMapper;
using CommentPlugin_v2.DTOs;
using CommentPlugin_v2.Models;

namespace CommentPlugin_v2.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
