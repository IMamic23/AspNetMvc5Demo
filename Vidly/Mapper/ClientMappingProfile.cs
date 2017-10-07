using AutoMapper;
using Vidly.Models;

namespace Vidly.Mapper
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<MovieDto, Movie>().ReverseMap();
        }
    }
}