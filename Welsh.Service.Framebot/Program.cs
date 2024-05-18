using Welsh.Framebot.Data.Enums;
using Welsh.Service.Framebot;

if (args.Length != 2)
    throw new ApplicationException("Need to specify bot config");

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var channelType = Enum.Parse<ChannelTypes>(args[1]);
builder.Services.AddCoreServices(builder.Configuration, channelType);
builder.Services.AddBotStates(args[0]);

var host = builder.Build();
host.Run();
