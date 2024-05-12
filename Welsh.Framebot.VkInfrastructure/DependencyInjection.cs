using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;
using Welsh.Framebot.Domain.Abstraction;

namespace Welsh.Framebot.VkInfrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddVkInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var config = new VkConfiguration();
        configuration.GetRequiredSection("Vk").Bind(config);

        services.AddSingleton<IVkApi, VkApi>(s =>
        {
            var api = new VkApi();
            api.Authorize(new ApiAuthParams { AccessToken = config.Token });
            return api;
        });

        services.AddSingleton<BotsLongPollHistoryParams>(s =>
        {
            var api = s.GetRequiredService<IVkApi>();
            var server = api.Groups.GetLongPollServer(config.CommunityId);
            return new() { Key = server.Key, Server = server.Server, Ts = server.Ts, Wait = config.Wait };
        });

        services.AddSingleton<IBotChannel, VkChannel>();

        return services;
    }
}
