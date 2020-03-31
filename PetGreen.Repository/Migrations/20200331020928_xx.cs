using Microsoft.EntityFrameworkCore.Migrations;

namespace PetGreen.Repository.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CDClinic_CDAddress_AddressID",
                table: "CDClinic");

            migrationBuilder.AddForeignKey(
                name: "FK_CDClinic_CDAddress_AddressID",
                table: "CDClinic",
                column: "AddressID",
                principalTable: "CDAddress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CDClinic_CDAddress_AddressID",
                table: "CDClinic");

            migrationBuilder.AddForeignKey(
                name: "FK_CDClinic_CDAddress_AddressID",
                table: "CDClinic",
                column: "AddressID",
                principalTable: "CDAddress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
