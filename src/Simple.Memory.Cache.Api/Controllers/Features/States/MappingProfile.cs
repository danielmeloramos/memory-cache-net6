using AutoMapper;
using Simple.Memory.Cache.Api.Controllers.Features.States.ViewModels;
using Simple.Memory.Cache.Domain.Features.States;

namespace Simple.Memory.Cache.Api.Controllers.Features.States
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<State, StateViewModel>();
        }
    }
}
