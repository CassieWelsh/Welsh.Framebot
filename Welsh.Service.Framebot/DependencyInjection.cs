using Welsh.Framebot.Domain.Abstraction;
using Welsh.Framebot.Standard;
using Welsh.Framebot.Standard.Actions;

namespace Welsh.Service.Framebot;

internal static class DependencyInjection
{
    internal static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<BotState, DefaultState>();
        services.AddSingleton<IBotStateContainer<BotState>, BotStateContainer<BotState>>();
        services.AddSingleton<IBotMessageProcessor, MessageProcessor>();
        services.AddSingleton<LongPollingService>();

        return services;
    }

    class DefaultState()
        : BotState(new EchoAction("Sample", null, null))
    {
    }
}
