namespace Welsh.Framebot.VkInfrastructure;

internal class VkConfiguration
{
    public string Token { get; set; } = string.Empty;
    public ulong CommunityId { get; set; }
    public int Wait { get; set; }
}
