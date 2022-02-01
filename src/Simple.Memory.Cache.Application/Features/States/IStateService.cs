using Simple.Memory.Cache.Domain.Features.States;

namespace Simple.Memory.Cache.Application.Features.States
{
    public interface IStateService
    {
        public IEnumerable<State> Get();
    }
}