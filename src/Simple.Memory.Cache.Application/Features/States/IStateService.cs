using Simple.Memory.Cache.Domain.Features.States;

namespace Simple.Memory.Cache.Application.Features.States
{
    public interface IStateService
    {
        IEnumerable<State> Get();
    }
}