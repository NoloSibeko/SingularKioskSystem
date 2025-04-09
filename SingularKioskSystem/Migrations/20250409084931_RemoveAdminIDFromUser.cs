using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SingularKioskSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAdminIDFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Users");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
