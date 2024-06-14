using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ABC.Migrations
{
    /// <inheritdoc />
    public partial class addmissingcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "approvalStatus",
                table: "ResourceUsing",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "approvalStatus",
                table: "ResourceUsing");
        }
    }
}
