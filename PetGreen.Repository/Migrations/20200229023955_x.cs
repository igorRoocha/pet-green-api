using Microsoft.EntityFrameworkCore.Migrations;

namespace PetGreen.Repository.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CDClinic_AddressID",
                table: "CDClinic");

            migrationBuilder.CreateIndex(
                name: "IX_CDClinic_AddressID",
                table: "CDClinic",
                column: "AddressID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CDClinic_AddressID",
                table: "CDClinic");

            migrationBuilder.CreateIndex(
                name: "IX_CDClinic_AddressID",
                table: "CDClinic",
                column: "AddressID");
        }
    }
}
