﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Welsh.Framebot.Data;

#nullable disable

namespace Welsh.Framebot.Data.Migrations
{
    [DbContext(typeof(FramebotContext))]
    [Migration("20240519093720_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Welsh.Framebot.Data.Models.Bot", b =>
                {
                    b.Property<int>("BotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BotId");

                    b.HasIndex("UserId");

                    b.ToTable("Bots");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotActionType", b =>
                {
                    b.Property<short>("ActionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ActionTypeId");

                    b.ToTable("ActionTypes");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotActionTypeParam", b =>
                {
                    b.Property<short>("ParamTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ParamTypeId");

                    b.ToTable("ActionTypeParams");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotChannel", b =>
                {
                    b.Property<int>("BotId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("ChannelType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BotId", "ChannelType");

                    b.ToTable("BotChannels");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotState", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BotId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StateId");

                    b.HasIndex("BotId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotStateAction", b =>
                {
                    b.Property<int>("ActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<short>("ActionTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NextActionId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NextState")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StateId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActionId");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("StateId");

                    b.ToTable("StateActions");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotStateActionParam", b =>
                {
                    b.Property<int>("ActionId")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ParamTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<short?>("BotActionTypeActionTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ActionId", "ParamTypeId");

                    b.HasIndex("BotActionTypeActionTypeId");

                    b.HasIndex("ParamTypeId");

                    b.ToTable("StateActionParams");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.Bot", b =>
                {
                    b.HasOne("Welsh.Framebot.Data.Models.User", "User")
                        .WithMany("Bots")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotChannel", b =>
                {
                    b.HasOne("Welsh.Framebot.Data.Models.Bot", "Bot")
                        .WithMany("Channels")
                        .HasForeignKey("BotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bot");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotState", b =>
                {
                    b.HasOne("Welsh.Framebot.Data.Models.Bot", "Bot")
                        .WithMany("States")
                        .HasForeignKey("BotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bot");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotStateAction", b =>
                {
                    b.HasOne("Welsh.Framebot.Data.Models.BotActionType", "ActionType")
                        .WithMany("Actions")
                        .HasForeignKey("ActionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Welsh.Framebot.Data.Models.BotState", "State")
                        .WithMany("Actions")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionType");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotStateActionParam", b =>
                {
                    b.HasOne("Welsh.Framebot.Data.Models.BotStateAction", "Action")
                        .WithMany("Params")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Welsh.Framebot.Data.Models.BotActionType", null)
                        .WithMany("Params")
                        .HasForeignKey("BotActionTypeActionTypeId");

                    b.HasOne("Welsh.Framebot.Data.Models.BotActionTypeParam", "Param")
                        .WithMany()
                        .HasForeignKey("ParamTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Param");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.Bot", b =>
                {
                    b.Navigation("Channels");

                    b.Navigation("States");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotActionType", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Params");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotState", b =>
                {
                    b.Navigation("Actions");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.BotStateAction", b =>
                {
                    b.Navigation("Params");
                });

            modelBuilder.Entity("Welsh.Framebot.Data.Models.User", b =>
                {
                    b.Navigation("Bots");
                });
#pragma warning restore 612, 618
        }
    }
}