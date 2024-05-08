using Welsh.Framebot.Domain.Abstraction;
using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain;

public class MessageProcessor(IBotStateContainer<BotState> stateContainer, BotState initialState)
    : IBotMessageProcessor
{
    private readonly IBotStateContainer<BotState> _stateContainer = stateContainer;
    private readonly BotState _initialState = initialState;

    public async Task ProcessMessageAsync(BotMessage message, CancellationToken ct)
    {
        var state = _stateContainer.GetState(message.UserId);
        if (state == null)
        {
            state = _initialState;
            _stateContainer.SetState(message.UserId, state);
        }

        var newState = await state.HandleAsync(message, ct);

        _stateContainer.SetState(message.UserId, newState);
    }
}
