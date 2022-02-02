using Newtonsoft.Json;
using Simple.Memory.Cache.Domain.Features.States;
using Simple.Memory.Cache.Infra.Cache;

namespace Simple.Memory.Cache.Application.Features.States
{
    public class StateService : IStateService
    {
        private readonly ICacheService _cacheService;

        public StateService(ICacheService cacheService) 
        {
            _cacheService = cacheService;
        }

        public IEnumerable<State> Get()
        {
            var key = "teste";
            var states = _cacheService.GetAsync<IEnumerable<State>>(key).Result;
            if (states == null)
            {
                using StreamReader streamReader = new("states.json");
                var data = streamReader.ReadToEnd();
                states = JsonConvert.DeserializeObject<IEnumerable<State>>(data);

                if(states != null)
                    _cacheService.SetAsync(key, states);
            }          

            return states;
        }
    }
}
