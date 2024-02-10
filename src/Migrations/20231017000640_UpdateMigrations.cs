using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Payment_PaymentId",
                table: "Installment");

            migrationBuilder.DropTable(
                name: "InstallmentTags");

            migrationBuilder.DropTable(
                name: "PaymentInstallments");

            migrationBuilder.AddColumn<int>(
                name: "InstallmentId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Payment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Installment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Installment",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Installment_InstallmentId",
                table: "Tag",
                column: "InstallmentId",
                principalTable: "Installment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Payment_PaymentId",
                table: "Installment");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Installment_InstallmentId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_InstallmentId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "InstallmentId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Installment");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Installment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "InstallmentTags",
                columns: table => new
                {
                    InstallementId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentTags", x => new { x.InstallementId, x.TagId });
                    table.ForeignKey(
                        name: "FK_InstallmentTags_Installment_InstallementId",
                        column: x => x.InstallementId,
                        principalTable: "Installment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstallmentTags_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInstallments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    InstallementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInstallments", x => new { x.PaymentId, x.InstallementId });
                    table.ForeignKey(
                        name: "FK_PaymentInstallments_Installment_InstallementId",
                        column: x => x.InstallementId,
                        principalTable: "Installment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentInstallments_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentTags_TagId",
                table: "InstallmentTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInstallments_InstallementId",
                table: "PaymentInstallments",
                column: "InstallementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Payment_PaymentId",
                table: "Installment",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id");
        }
    }
}
