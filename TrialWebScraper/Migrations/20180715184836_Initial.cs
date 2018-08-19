using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrialWebScraper.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SnapShot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    SnapShotTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnapShot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(nullable: true),
                    LastPrice = table.Column<decimal>(nullable: false),
                    Change = table.Column<decimal>(nullable: false),
                    PercentChg = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Volume = table.Column<decimal>(nullable: false),
                    MarketCap = table.Column<decimal>(nullable: false),
                    SnapShotID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stock_SnapShot_SnapShotID",
                        column: x => x.SnapShotID,
                        principalTable: "SnapShot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_SnapShotID",
                table: "Stock",
                column: "SnapShotID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "SnapShot");
        }
    }
}
