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
                name: "StateTypes",
                columns: table => new
                {
                    StateTypeId = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTypes", x => x.StateTypeId);
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
                name: "StateParams",
                columns: table => new
                {
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StateTypeId = table.Column<short>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ParamType = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateParams", x => x.ParamId);
                    table.ForeignKey(
                        name: "FK_StateParams_StateTypes_StateTypeId",
                        column: x => x.StateTypeId,
                        principalTable: "StateTypes",
                        principalColumn: "StateTypeId",
                        onDelete: ReferentialAction.Cascade);
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
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NextStateId = table.Column<int>(type: "INTEGER", nullable: true),
                    StateTypeId = table.Column<short>(type: "INTEGER", nullable: false),
                    EnterMessage = table.Column<string>(type: "TEXT", nullable: true),
                    ExitMessage = table.Column<string>(type: "TEXT", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_States_StateTypes_StateTypeId",
                        column: x => x.StateTypeId,
                        principalTable: "StateTypes",
                        principalColumn: "StateTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateParamValues",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateParamValues", x => new { x.StateId, x.ParamId });
                    table.ForeignKey(
                        name: "FK_StateParamValues_StateParams_ParamId",
                        column: x => x.ParamId,
                        principalTable: "StateParams",
                        principalColumn: "ParamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateParamValues_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bots_UserId",
                table: "Bots",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StateParams_StateTypeId",
                table: "StateParams",
                column: "StateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StateParamValues_ParamId",
                table: "StateParamValues",
                column: "ParamId");

            migrationBuilder.CreateIndex(
                name: "IX_States_BotId",
                table: "States",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_States_StateTypeId",
                table: "States",
                column: "StateTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotChannels");

            migrationBuilder.DropTable(
                name: "StateParamValues");

            migrationBuilder.DropTable(
                name: "StateParams");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Bots");

            migrationBuilder.DropTable(
                name: "StateTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
