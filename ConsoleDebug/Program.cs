//var services = new ServiceCollection();
//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json")
//    .Build();

//services.AddVkInfrastructure(configuration);
//services.AddCoreServices();

//using var serviceProvider = services.BuildServiceProvider();
//using var scope = serviceProvider.CreateScope();

using System.Diagnostics;

var p = new ProcessStartInfo()
{
    FileName = "C:\\Users\\maksi\\Desktop\\Repos\\Welsh.Framebot\\Welsh.Service.Framebot\\bin\\Debug\\net8.0\\Welsh.Service.Framebot.exe",
    RedirectStandardOutput = true,
    RedirectStandardError = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

var process = new Process() { StartInfo = p };
process.Start();

var process2 = new Process() { StartInfo = p };
process2.Start();

await Task.Delay(20000);

process.Kill();
process2.Kill();



