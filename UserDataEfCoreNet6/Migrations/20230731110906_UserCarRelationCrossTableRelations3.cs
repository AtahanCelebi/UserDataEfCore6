using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserDataEfCoreNet6.Migrations
{
    public partial class UserCarRelationCrossTableRelations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CarName",
                table: "Car",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarName",
                keyValue: null,
                column: "CarName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CarName",
                table: "Car",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
