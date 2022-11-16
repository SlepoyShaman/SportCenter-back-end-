using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportCenter.Migrations
{
    public partial class ChangeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Memberships_MembershipId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MembershipId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "MembershipId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MembershipId",
                table: "AspNetUsers",
                column: "MembershipId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Memberships_MembershipId",
                table: "AspNetUsers",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Memberships_MembershipId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MembershipId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "MembershipId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MembershipId",
                table: "AspNetUsers",
                column: "MembershipId",
                unique: true,
                filter: "[MembershipId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Memberships_MembershipId",
                table: "AspNetUsers",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id");
        }
    }
}
