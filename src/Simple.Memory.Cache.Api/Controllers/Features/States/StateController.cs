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

        [HttpGet]
        public IEnumerable<StateViewModel> Get()
        {
            _logger.LogInformation("Iniciando a obtenção dos estados utilizando MemoryCache.");
            var statesCallback = _stateService.Get();

            _logger.LogInformation($"Obtido os estados utilizando MemoryCache. Quantidade {statesCallback.Count()}.");
            var states = _mapper.Map<IEnumerable<State>, IEnumerable<StateViewModel>>(statesCallback);

            _logger.LogInformation("Retornando os estados utilizando MemoryCache.");
            return states;
        }
    }
}