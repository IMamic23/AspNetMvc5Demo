using AutoMapper;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Mapper
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieFormViewModel>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}