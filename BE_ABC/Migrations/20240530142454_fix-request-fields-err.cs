using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ABC.Migrations
{
    /// <inheritdoc />
    public partial class fixrequestfieldserr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestType_requestType",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "requestType",
                table: "Request",
                newName: "requestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_requestType",
                table: "Request",
                newName: "IX_Request_requestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestType_requestTypeId",
                table: "Request",
                column: "requestTypeId",
                principalTable: "RequestType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestType_requestTypeId",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "requestTypeId",
                table: "Request",
                newName: "requestType");

            migrationBuilder.RenameIndex(
                name: "IX_Request_requestTypeId",
                table: "Request",
                newName: "IX_Request_requestType");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestType_requestType",
                table: "Request",
                column: "requestType",
                principalTable: "RequestType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
