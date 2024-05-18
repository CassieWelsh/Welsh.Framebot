using Microsoft.EntityFrameworkCore;
using Welsh.Framebot.Data.Models;

namespace Welsh.Framebot.Data;

public class FramebotContext(DbContextOptions<FramebotContext> options) : DbContext(options)
{
    #region DbSets

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Bot> Bots { get; set; }
    public virtual DbSet<BotChannel> BotChannels { get; set; }
    public virtual DbSet<BotState> States { get; set; }
    public virtual DbSet<BotStateAction> StateActions { get; set; }
    public virtual DbSet<BotActionType> ActionTypes { get; set; }
    public virtual DbSet<BotActionTypeParam> ActionTypeParams { get; set; }
    public virtual DbSet<BotStateActionParam> StateActionParams { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(u => u.UserId);
        });

        modelBuilder.Entity<Bot>(e =>
        {
            e.HasKey(b => b.BotId);

            e.HasOne(b => b.User)
             .WithMany(u => u.Bots)
             .HasForeignKey(b => b.UserId);
        });

        modelBuilder.Entity<BotChannel>(e =>
        {
            e.HasKey(c => new { c.BotId, c.ChannelType });

            e.HasOne(c => c.Bot)
             .WithMany(b => b.Channels)
             .HasForeignKey(c => c.BotId);
        });

        modelBuilder.Entity<BotState>(e =>
        {
            e.HasKey(s => s.StateId);

            e.HasOne(s => s.Bot)
             .WithMany(b => b.States)
             .HasForeignKey(s => s.BotId);
        });

        modelBuilder.Entity<BotStateAction>(e =>
        {
            e.HasKey(a => a.ActionId);

            e.HasOne(a => a.State)
             .WithMany(b => b.Actions)
             .HasForeignKey(a => a.StateId);

            e.HasOne(a => a.ActionType)
             .WithMany(at => at.Actions)
             .HasForeignKey(a => a.ActionTypeId);
        });

        modelBuilder.Entity<BotActionType>(e =>
        {
            e.HasKey(at => at.ActionTypeId);
        });

        modelBuilder.Entity<BotStateActionParam>(e =>
        {
            e.HasKey(ap => new { ap.ActionId, ap.ParamTypeId });

            e.HasOne(ap => ap.Action)
             .WithMany(a => a.Params)
             .HasForeignKey(ap => ap.ActionId);

            e.HasOne(ap => ap.Param)
             .WithMany()
             .HasForeignKey(ap => ap.ParamTypeId);
        });

        base.OnModelCreating(modelBuilder);
    }
}
