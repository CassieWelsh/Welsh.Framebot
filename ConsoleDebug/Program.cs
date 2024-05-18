using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Welsh.Framebot.Data;
using Welsh.Framebot.Data.Enums;
using Welsh.Framebot.VkInfrastructure;
using Welsh.Service.Framebot;

var services = new ServiceCollection();
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

services.AddVkInfrastructure(configuration);
services.AddCoreServices(configuration, ChannelTypes.Vk);
services.AddDbContext<FramebotContext>(c => c.UseSqlite("Data Source=mydb.db"));

using var serviceProvider = services.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

using var context = scope.ServiceProvider.GetRequiredService<FramebotContext>();
context.Database.Migrate();

//using System.Diagnostics;

//var p = new ProcessStartInfo()
//{
//    FileName = "C:\\Users\\maksi\\Desktop\\Repos\\Welsh.Framebot\\Welsh.Service.Framebot\\bin\\Debug\\net8.0\\Welsh.Service.Framebot.exe",
//    RedirectStandardOutput = true,
//    RedirectStandardError = true,
//    UseShellExecute = false,
//    CreateNoWindow = true
//};

//var process = new Process() { StartInfo = p };
//process.Start();

//var process2 = new Process() { StartInfo = p };
//process2.Start();

//await Task.Delay(20000);

//process.Kill();
//process2.Kill();



