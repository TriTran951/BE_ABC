using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ABC.Migrations
{
    /// <inheritdoc />
    public partial class addfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "decidedAt",
                table: "ResourceUsing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "decisionDetail",
                table: "ResourceUsing",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "decidedAt",
                table: "ResourceUsing");

            migrationBuilder.DropColumn(
                name: "decisionDetail",
                table: "ResourceUsing");
        }
    }
}
