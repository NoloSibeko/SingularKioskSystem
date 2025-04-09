using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SingularKioskSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminIDToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Users");
        }
    }
}
