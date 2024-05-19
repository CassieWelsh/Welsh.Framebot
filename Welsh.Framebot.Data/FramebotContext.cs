using Microsoft.EntityFrameworkCore;
using Welsh.Framebot.Data.Models;

namespace Welsh.Framebot.Data;

public class FramebotContext : DbContext
{
    ////////////////////////////////////////////////////////////////////////////////
    //UNCOMMENT FOR MIGRATIONS
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlite("Data Source=c:\\mydb.db;Version=3;");
    //}

    //public FramebotContext() { }
    ////////////////////////////////////////////////////////////////////////////////

    public FramebotContext(DbContextOptions<FramebotContext> options) : base(options)
    {
    }

    #region DbSets

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Bot> Bots { get; set; }
    public virtual DbSet<BotChannel> BotChannels { get; set; }
    public virtual DbSet<BotState> States { get; set; }
    public virtual DbSet<BotStateType> StateTypes { get; set; }
    public virtual DbSet<BotStateParamValue> StateParamValues { get; set; }
    public virtual DbSet<BotStateParam> StateParams { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>(e =>
        {
            e.HasKey(u => u.UserId);
        });

        builder.Entity<Bot>(e =>
        {
            e.HasKey(b => b.BotId);

            e.HasOne(b => b.User)
             .WithMany(u => u.Bots)
             .HasForeignKey(b => b.UserId);
        });

        builder.Entity<BotChannel>(e =>
        {
            e.HasKey(c => new { c.BotId, c.ChannelType });

            e.HasOne(c => c.Bot)
             .WithMany(b => b.Channels)
             .HasForeignKey(c => c.BotId);
        });

        builder.Entity<BotState>(e =>
        {
            e.HasKey(s => s.StateId);

            e.HasOne(s => s.Bot)
             .WithMany(b => b.States)
             .HasForeignKey(s => s.BotId);

            e.HasOne(s => s.StateType)
             .WithMany(s => s.States)
             .HasForeignKey(s => s.StateTypeId);
        });

        builder.Entity<BotStateType>(e =>
        {
            e.HasKey(st => st.StateTypeId);
        });

        builder.Entity<BotStateParamValue>(e =>
        {
            e.HasKey(v => new { v.StateId, v.ParamId });

            e.HasOne(v => v.State)
             .WithMany(s => s.StateParamValues)
             .HasForeignKey(v => v.StateId);

            e.HasOne(v => v.StateParam)
             .WithMany()
             .HasForeignKey(v => v.ParamId);
        });

        builder.Entity<BotStateParam>(e =>
        {
            e.HasKey(p => p.ParamId);

            e.HasOne(p => p.StateType)
             .WithMany(t => t.StateParams)
             .HasForeignKey(p => p.StateTypeId);
        });
    }
}
