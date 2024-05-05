namespace Welsh.Framebot.Domain.Model;

public class BotMessage(long userId, string text)
{
    public long UserId { get; set; } = userId;
    public string Text { get; set; } = text;
}