using Welsh.Framebot.Data.Enums;
using Welsh.Framebot.Domain.Abstraction;
using Welsh.Framebot.Standard;
using Welsh.Framebot.Standard.Actions;
using Welsh.Framebot.Standard.Parser;
using Welsh.Framebot.VkInfrastructure;

namespace Welsh.Service.Framebot;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration, ChannelTypes channelType)
    {
        services.AddSingleton<IBotStateContainer<BotState>, BotStateContainer<BotState>>();
        services.AddSingleton<IBotMessageProcessor, MessageProcessor>();
        services.AddSingleton<LongPollingService>();

        switch (channelType)
        {
            case ChannelTypes.Vk:
                services.AddVkInfrastructure(configuration);
                break;
        }

        return services;
    }

    public static IServiceCollection AddBotStates(this IServiceCollection services, string config)
    {
        var parser = new ConfigParser();
        var initialState = parser.Parse(config);
        if (initialState == null)
        {
            throw new ApplicationException("Config could not be parsed correctly");
        }

        services.AddSingleton(initialState);
        return services;
    }

    class DefaultState()
        : BotState(new EchoAction(null, null))
    {
    }
}
