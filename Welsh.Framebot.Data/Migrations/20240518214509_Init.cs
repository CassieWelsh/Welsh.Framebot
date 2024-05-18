using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Welsh.Framebot.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionTypeParams",
                columns: table => new
                {
                    ParamTypeId = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActionTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypeParams", x => x.ParamTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    ActionTypeId = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.ActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Bots",
                columns: table => new
                {
                    BotId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bots", x => x.BotId);
                    table.ForeignKey(
                        name: "FK_Bots_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotChannels",
                columns: table => new
                {
                    BotId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChannelType = table.Column<byte>(type: "INTEGER", nullable: false),
                    Token = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotChannels", x => new { x.BotId, x.ChannelType });
                    table.ForeignKey(
                        name: "FK_BotChannels_Bots_BotId",
                        column: x => x.BotId,
                        principalTable: "Bots",
                        principalColumn: "BotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BotId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_States_Bots_BotId",
                        column: x => x.BotId,
                        principalTable: "Bots",
                        principalColumn: "BotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateActions",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StateId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionTypeId = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateActions", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_StateActions_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateActions_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateActionParams",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParamTypeId = table.Column<short>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    BotActionTypeActionTypeId = table.Column<short>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateActionParams", x => new { x.ActionId, x.ParamTypeId });
                    table.ForeignKey(
                        name: "FK_StateActionParams_ActionTypeParams_ParamTypeId",
                        column: x => x.ParamTypeId,
                        principalTable: "ActionTypeParams",
                        principalColumn: "ParamTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateActionParams_ActionTypes_BotActionTypeActionTypeId",
                        column: x => x.BotActionTypeActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "ActionTypeId");
                    table.ForeignKey(
                        name: "FK_StateActionParams_StateActions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "StateActions",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bots_UserId",
                table: "Bots",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionParams_BotActionTypeActionTypeId",
                table: "StateActionParams",
                column: "BotActionTypeActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionParams_ParamTypeId",
                table: "StateActionParams",
                column: "ParamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActions_ActionTypeId",
                table: "StateActions",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActions_StateId",
                table: "StateActions",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_BotId",
                table: "States",
                column: "BotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotChannels");

            migrationBuilder.DropTable(
                name: "StateActionParams");

            migrationBuilder.DropTable(
                name: "ActionTypeParams");

            migrationBuilder.DropTable(
                name: "StateActions");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Bots");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
