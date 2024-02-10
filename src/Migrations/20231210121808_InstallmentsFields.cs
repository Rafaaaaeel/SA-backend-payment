using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApp.Migrations
{
    /// <inheritdoc />
    public partial class InstallmentsFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Final",
                table: "Installment");

            migrationBuilder.RenameColumn(
                name: "Initial",
                table: "Installment",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Installment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Installment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Installment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Installment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Installment");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Installment");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Installment",
                newName: "Initial");

            migrationBuilder.AddColumn<DateTime>(
                name: "Final",
                table: "Installment",
                type: "datetime2",
                nullable: true);
        }
    }
}
