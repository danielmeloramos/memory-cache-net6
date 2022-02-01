using Newtonsoft.Json;
using Simple.Memory.Cache.Domain.Features.States;
using Simple.Memory.Cache.Infra.Cache;

namespace Simple.Memory.Cache.Application.Features.States
{
    public class StateService : IStateService
    {
        private readonly ICacheService<State> _cacheService;

        public StateService(ICacheService<State> cacheService) 
        {
            _cacheService = cacheService;
        }

        public IEnumerable<State> Get()
        {
            using StreamReader streamReader = new("states.json");

            var data = streamReader.ReadToEnd();

            var states = JsonConvert.DeserializeObject<IEnumerable<State>>(data);

            return states;
        }
    }
}
