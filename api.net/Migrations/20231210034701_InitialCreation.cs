using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.net.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    doctor_name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    doctor_email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    patient_name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    patient_email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    status_name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_scheduling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    doctor_id = table.Column<int>(type: "INTEGER", nullable: false),
                    patient_id = table.Column<int>(type: "INTEGER", nullable: false),
                    scheduling_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_scheduling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_scheduling_tb_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "tb_doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_scheduling_tb_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "tb_patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_scheduling_tb_status_status_id",
                        column: x => x.status_id,
                        principalTable: "tb_status",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tb_status",
                columns: new[] { "Id", "status_name" },
                values: new object[] { 1, "Confirmado" });

            migrationBuilder.InsertData(
                table: "tb_status",
                columns: new[] { "Id", "status_name" },
                values: new object[] { 2, "Cancelado" });

            migrationBuilder.InsertData(
                table: "tb_status",
                columns: new[] { "Id", "status_name" },
                values: new object[] { 3, "Aguardando confirmação" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_scheduling_doctor_id",
                table: "tb_scheduling",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_scheduling_patient_id",
                table: "tb_scheduling",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_scheduling_status_id",
                table: "tb_scheduling",
                column: "status_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_scheduling");

            migrationBuilder.DropTable(
                name: "tb_doctors");

            migrationBuilder.DropTable(
                name: "tb_patients");

            migrationBuilder.DropTable(
                name: "tb_status");
        }
    }
}
