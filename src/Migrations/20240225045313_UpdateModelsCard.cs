using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxExpanse",
                table: "Installment");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxExpanse",
                table: "Card",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxExpanse",
                table: "Card");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxExpanse",
                table: "Installment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
