using AutoMapper;
using Vidly.Models;
using Vidly.Models.ModelDto;
using Vidly.ViewModels;

namespace Vidly.Mapper
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<MembershipType, MembershipTypeDto>().ReverseMap();
            CreateMap<Movie, MovieFormViewModel>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}