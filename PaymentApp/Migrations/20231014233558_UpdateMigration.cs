using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Installment");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailOwner",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "EmailOwner",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Payment");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Installment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
