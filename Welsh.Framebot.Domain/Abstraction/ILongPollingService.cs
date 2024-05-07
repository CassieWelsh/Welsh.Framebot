namespace Welsh.Framebot.Domain.Abstraction
{
    public interface ILongPollingService
    {
        Task PollAsync(CancellationToken ct);
    }
}