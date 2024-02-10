using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldsNamesInstallment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Month_MonthId",
                table: "Installment");

            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Year_YearId",
                table: "Installment");

            migrationBuilder.DropIndex(
                name: "IX_Installment_MonthId",
                table: "Installment");

            migrationBuilder.DropColumn(
                name: "MonthId",
                table: "Installment");

            migrationBuilder.AlterColumn<int>(
                name: "YearId",
                table: "Installment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Year_YearId",
                table: "Installment",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Year_YearId",
                table: "Installment");

            migrationBuilder.AlterColumn<int>(
                name: "YearId",
                table: "Installment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MonthId",
                table: "Installment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Installment_MonthId",
                table: "Installment",
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
    }
}
