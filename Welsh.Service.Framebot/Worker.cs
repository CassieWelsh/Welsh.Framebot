using Welsh.Framebot.Domain;

namespace Welsh.Service.Framebot;

public class Worker(ILogger<Worker> logger, LongPollingService service) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly LongPollingService _service = service;

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            try
            {
                await _service.PollAsync(ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
