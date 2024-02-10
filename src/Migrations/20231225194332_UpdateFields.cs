using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Payment_PaymentId",
                table: "Installment");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Installment",
                newName: "MonthId");

            migrationBuilder.RenameIndex(
                name: "IX_Installment_PaymentId",
                table: "Installment",
                newName: "IX_Installment_MonthId");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Expiration",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "Installment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Month_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Year_Month_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installment_YearId",
                table: "Installment",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Month_PaymentId",
                table: "Month",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Year_MonthId",
                table: "Year",
                column: "MonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Month_MonthId",
                table: "Installment",
                column: "MonthId",
                principalTable: "Month",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Year_YearId",
                table: "Installment",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Month_MonthId",
                table: "Installment");

            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Year_YearId",
                table: "Installment");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropIndex(
                name: "IX_Installment_YearId",
                table: "Installment");

            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Installment");

            migrationBuilder.RenameColumn(
                name: "MonthId",
                table: "Installment",
                newName: "PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Installment_MonthId",
                table: "Installment",
                newName: "IX_Installment_PaymentId");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallmentId = table.Column<int>(type: "int", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Installment_InstallmentId",
                        column: x => x.InstallmentId,
                        principalTable: "Installment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_InstallmentId",
                table: "Tag",
                column: "InstallmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Payment_PaymentId",
                table: "Installment",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
