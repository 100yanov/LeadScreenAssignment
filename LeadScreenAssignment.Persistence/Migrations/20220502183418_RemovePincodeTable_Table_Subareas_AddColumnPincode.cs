using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadScreenAssignment.Persistence.Migrations
{
    public partial class RemovePincodeTable_Table_Subareas_AddColumnPincode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubAreas_PinCodes_PinCodeId",
                table: "SubAreas");

            migrationBuilder.DropTable(
                name: "PinCodes");

            migrationBuilder.DropIndex(
                name: "IX_SubAreas_PinCodeId",
                table: "SubAreas");

            migrationBuilder.DropColumn(
                name: "PinCodeId",
                table: "SubAreas");

            migrationBuilder.AddColumn<string>(
                name: "PinCode",
                table: "SubAreas",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "SubAreas");

            migrationBuilder.AddColumn<Guid>(
                name: "PinCodeId",
                table: "SubAreas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PinCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinCodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubAreas_PinCodeId",
                table: "SubAreas",
                column: "PinCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubAreas_PinCodes_PinCodeId",
                table: "SubAreas",
                column: "PinCodeId",
                principalTable: "PinCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
