using System.Collections.Immutable;
using Welsh.Framebot.Domain.Abstraction;

namespace Welsh.Framebot.Domain;

public class BotStateContainer<T> : IBotStateContainer<T> where T : class
{
    private ImmutableDictionary<long, T> _states = ImmutableDictionary<long, T>.Empty;

    public T? GetState(long userId)
        => _states.TryGetValue(userId, out var state) ? state : null;

    public void SetState(long userId, T state)
        => _states.SetItem(userId, state);
}
