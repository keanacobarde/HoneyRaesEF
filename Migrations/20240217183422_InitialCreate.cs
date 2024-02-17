using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HoneyRaesEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Specialty = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Emergency = table.Column<bool>(type: "boolean", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTickets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "123 Witch Lane", "Salem" },
                    { 2, "124 Witch Lane", "Saleoomi" },
                    { 3, "125 Witch Lane", "Salogna" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Specialty" },
                values: new object[,]
                {
                    { 1, "Keana", "Dealing with Salems" },
                    { 2, "Kiki", "Dealing with Saleoomis" },
                    { 3, "Kia", "Dealing with Salognas" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTickets",
                columns: new[] { "Id", "CustomerId", "DateCompleted", "Description", "Emergency", "EmployeeId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The salem needs a Cauldron", false, 1 },
                    { 2, 2, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The saleoomi needs a Cauldron", true, 2 },
                    { 3, 3, null, "The salogna needs a Cauldron", true, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTickets_EmployeeId",
                table: "ServiceTickets",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ServiceTickets");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
