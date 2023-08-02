using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserDataEfCoreNet6.Migrations
{
    public partial class UserDeleteCascadeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
