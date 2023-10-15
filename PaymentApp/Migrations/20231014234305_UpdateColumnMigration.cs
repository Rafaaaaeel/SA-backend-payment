using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "initial",
                table: "Installment",
                newName: "Initial");

            migrationBuilder.RenameColumn(
                name: "final",
                table: "Installment",
                newName: "Final");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Initial",
                table: "Installment",
                newName: "initial");

            migrationBuilder.RenameColumn(
                name: "Final",
                table: "Installment",
                newName: "final");
        }
    }
}
