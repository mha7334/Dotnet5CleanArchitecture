using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Api.Automapper
{
    public class GadgetMapperProfile : Profile
    {
        public GadgetMapperProfile()
        {
            CreateMap<Gadget,GadgetDto>();
            
        }
    }
}
