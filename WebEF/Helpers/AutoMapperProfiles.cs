using AutoMapper;
using WebEF.Dtos;
using WebEF.Models;

namespace WebEF.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<ActorCreacionDto, Actor>()
                .ForMember(x => x.UrlFoto, options => options.Ignore());
            CreateMap<ActorEdicionDto, Actor>()
                .ForMember(x => x.UrlFoto, options => options.Ignore()).ReverseMap();
            RecognizePostfixes("File");
            CreateMap<PeliculaEdicionDto, Pelicula>()
                .ForMember(x => x.UrlFoto, options => options.Ignore()).ReverseMap();
            CreateMap<ActorPatchDto, Actor>().ReverseMap();
        }
    }
}
