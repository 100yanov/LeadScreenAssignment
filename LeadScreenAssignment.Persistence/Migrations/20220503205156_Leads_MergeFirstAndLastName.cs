using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadScreenAssignment.Persistence.Migrations
{
    public partial class Leads_MergeFirstAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Leads");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Leads",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Leads",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Leads",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
