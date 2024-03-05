using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPS.Migrations
{
    /// <inheritdoc />
    public partial class shivam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(name: "Father_Name", type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(name: "Mother_Name", type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlterContect = table.Column<string>(name: "Alter_Contect", type: "nvarchar(max)", nullable: false),
                    AddmissionDate = table.Column<DateTime>(name: "Addmission_Date", type: "datetime2", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    January = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    February = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    March = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    April = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    May = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    June = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    July = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    August = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    September = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    October = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    November = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    December = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlterContect = table.Column<string>(name: "Alter_Contect", type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateTime>(name: "Join_Date", type: "datetime2", nullable: false),
                    January = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    February = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    March = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    April = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    May = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    June = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    July = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    August = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    September = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    October = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    November = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    December = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Ids",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Ids", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "User_Ids");
        }
    }
}
