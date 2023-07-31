using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserDataEfCoreNet6.Migrations
{
    public partial class UserCarDBSetCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCar_Car_CarId",
                table: "UserCar");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCar_Users_UserId",
                table: "UserCar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCar",
                table: "UserCar");

            migrationBuilder.RenameTable(
                name: "UserCar",
                newName: "UserCars");

            migrationBuilder.RenameIndex(
                name: "IX_UserCar_CarId",
                table: "UserCars",
                newName: "IX_UserCars_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCars",
                table: "UserCars",
                columns: new[] { "UserId", "CarId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCars_Car_CarId",
                table: "UserCars",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCars_Users_UserId",
                table: "UserCars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCars_Car_CarId",
                table: "UserCars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCars_Users_UserId",
                table: "UserCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCars",
                table: "UserCars");

            migrationBuilder.RenameTable(
                name: "UserCars",
                newName: "UserCar");

            migrationBuilder.RenameIndex(
                name: "IX_UserCars_CarId",
                table: "UserCar",
                newName: "IX_UserCar_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCar",
                table: "UserCar",
                columns: new[] { "UserId", "CarId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCar_Car_CarId",
                table: "UserCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCar_Users_UserId",
                table: "UserCar",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
