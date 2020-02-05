using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetGreen.Repository.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDClinic",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SocialReason = table.Column<string>(nullable: true),
                    TaxId = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDClinic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CDProfile",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDProfile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CDState",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CDSchedules",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Day = table.Column<string>(nullable: false),
                    StartHour = table.Column<string>(nullable: false),
                    EndHour = table.Column<string>(nullable: false),
                    ClinicID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDSchedules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CDSchedules_CDClinic_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "CDClinic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CDUser",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    ProfileID = table.Column<Guid>(nullable: false),
                    ClinicID = table.Column<Guid>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CDUser_CDClinic_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "CDClinic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CDUser_CDProfile_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "CDProfile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CDCity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    IBGE = table.Column<string>(nullable: false),
                    StateID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDCity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CDCity_CDState_StateID",
                        column: x => x.StateID,
                        principalTable: "CDState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CDContact",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Number = table.Column<string>(nullable: false),
                    ClinicID = table.Column<Guid>(nullable: true),
                    UserID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDContact", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CDContact_CDClinic_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "CDClinic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CDContact_CDUser_UserID",
                        column: x => x.UserID,
                        principalTable: "CDUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CDAddress",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Cep = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Neighborhood = table.Column<string>(nullable: false),
                    Complement = table.Column<string>(nullable: true),
                    CityID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CDAddress_CDCity_CityID",
                        column: x => x.CityID,
                        principalTable: "CDCity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CDAddress_CityID",
                table: "CDAddress",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_CDCity_StateID",
                table: "CDCity",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_CDContact_ClinicID",
                table: "CDContact",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_CDContact_UserID",
                table: "CDContact",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CDSchedules_ClinicID",
                table: "CDSchedules",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_CDUser_ClinicID",
                table: "CDUser",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_CDUser_ProfileID",
                table: "CDUser",
                column: "ProfileID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDAddress");

            migrationBuilder.DropTable(
                name: "CDContact");

            migrationBuilder.DropTable(
                name: "CDSchedules");

            migrationBuilder.DropTable(
                name: "CDCity");

            migrationBuilder.DropTable(
                name: "CDUser");

            migrationBuilder.DropTable(
                name: "CDState");

            migrationBuilder.DropTable(
                name: "CDClinic");

            migrationBuilder.DropTable(
                name: "CDProfile");
        }
    }
}
