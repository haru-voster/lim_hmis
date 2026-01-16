using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TestValue",
                table: "result_table",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TestName",
                table: "result_table",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_result_table_LabRequestId",
                table: "result_table",
                column: "LabRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_result_table_LabRequests_LabRequestId",
                table: "result_table",
                column: "LabRequestId",
                principalTable: "LabRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_result_table_LabRequests_LabRequestId",
                table: "result_table");

            migrationBuilder.DropIndex(
                name: "IX_result_table_LabRequestId",
                table: "result_table");

            migrationBuilder.AlterColumn<string>(
                name: "TestValue",
                table: "result_table",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TestName",
                table: "result_table",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
