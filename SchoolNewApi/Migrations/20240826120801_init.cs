using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolNewApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatricNo",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatricNo",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
