using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;
using Welsh.Framebot.Domain.Abstraction;

namespace Welsh.Framebot.VkInfrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddVkInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IVkApi, VkApi>(s =>
        {
            var api = new VkApi();
            api.Authorize(new ApiAuthParams { AccessToken = "" });
            return api;
        });

        services.AddSingleton<BotsLongPollHistoryParams>(s =>
        {
            var api = s.GetRequiredService<IVkApi>();
            var server = api.Groups.GetLongPollServer(225796199);
            return new() { Key = server.Key, Server = server.Server, Ts = server.Ts, Wait = 10 };
        });

        services.AddSingleton<IBotChannel, VkChannel>();

        return services;
    }
}
