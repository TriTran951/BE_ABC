using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ABC.Migrations
{
    /// <inheritdoc />
    public partial class addresourceevent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "resourceId",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_resourceId",
                table: "Event",
                column: "resourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Resource_resourceId",
                table: "Event",
                column: "resourceId",
                principalTable: "Resource",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Resource_resourceId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_resourceId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "resourceId",
                table: "Event");
        }
    }
}
