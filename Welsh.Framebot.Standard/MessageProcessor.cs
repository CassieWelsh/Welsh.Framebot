using Welsh.Framebot.Domain.Abstraction;
using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Standard;

public class MessageProcessor(IBotStateContainer<BotState> stateContainer, BotState initialState)
    : IBotMessageProcessor
{
    private readonly IBotStateContainer<BotState> _stateContainer = stateContainer;
    private readonly BotState _initialState = initialState;

    public async Task<string?> ProcessMessageAsync(BotMessage message, CancellationToken ct)
    {
        var state = _stateContainer.GetState(message.UserId);
        if (state == null)
        {
            state = _initialState;
            _stateContainer.SetState(message.UserId, state);
        }

        var (newState, replyMessage) = await state.HandleAsync(message, ct);

        if (newState != null)
            _stateContainer.SetState(message.UserId, newState);

        return replyMessage;
    }
}
