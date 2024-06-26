﻿using Welsh.Framebot.Domain.Abstraction;
using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Standard.Actions;

public class EchoAction(BotActionBase? nextAction, BotState? nextState)
    : BotActionBase(nextAction, nextState)
{
    public override Task<(BotState? state, string? message)> ExecuteAsync(BotMessage message, CancellationToken ct)
    {
        return Task.FromResult<ValueTuple<BotState?, string?>>((null, message.Text));
    }
}
