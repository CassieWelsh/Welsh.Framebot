namespace Welsh.Framebot.Domain.Abstraction
{
    public interface IBotStateContainer<T> where T : notnull
    {
        T GetState(long userId);
        void SetState(long userId, T state);
    }
}