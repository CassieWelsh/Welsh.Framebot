using Microsoft.Extensions.DependencyInjection;
using Welsh.Framebot.Domain.Abstraction;
using Welsh.Framebot.VkInfrastructure;

var services = new ServiceCollection();
services.AddVkInfrastructure();

using var serviceProvider = services.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

var channel = scope.ServiceProvider.GetRequiredService<IBotChannel>();

await channel.FetchAsync(default);

