using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Month_Payment_PaymentId",
                table: "Month");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Month",
                newName: "CardId");

            migrationBuilder.RenameIndex(
                name: "IX_Month_PaymentId",
                table: "Month",
                newName: "IX_Month_CardId");

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Expiration = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailOwner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Month_Card_CardId",
                table: "Month",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Month_Card_CardId",
                table: "Month");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Month",
                newName: "PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Month_CardId",
                table: "Month",
                newName: "IX_Month_PaymentId");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Month_Payment_PaymentId",
                table: "Month",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
