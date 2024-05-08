using Welsh.Framebot.VkInfrastructure;
using Welsh.Service.Framebot;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddVkInfrastructure();

var host = builder.Build();
host.Run();
