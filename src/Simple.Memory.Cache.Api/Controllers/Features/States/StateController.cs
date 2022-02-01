using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simple.Memory.Cache.Api.Controllers.Features.States.ViewModels;
using Simple.Memory.Cache.Application.Features.States;
using Simple.Memory.Cache.Domain.Features.States;

namespace Simple.Memory.Cache.Api.Controllers.Features.States
{
    [ApiController]
    [Route("[controller]")]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;
        private readonly ILogger<StateController> _logger;

        public StateController(IStateService stateService, IMapper mapper, ILogger<StateController> logger)
        {
            _stateService = stateService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Name = "GetStates")]
        public IEnumerable<StateViewModel> Get()
        {
            var statesCallback = _stateService.Get();
            var states = _mapper.Map<IEnumerable<State>, IEnumerable<StateViewModel>>(statesCallback);
            return states;
        }
    }
}