using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ABC.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUDDocument = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUDEvent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    minGrade = table.Column<int>(type: "int", nullable: false),
                    action = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    isPretected = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUDPost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostType", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ResourceType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUDResourceUsing = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUDResource = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    resourceTypeId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isFree = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.id);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceType_resourceTypeId",
                        column: x => x.resourceTypeId,
                        principalTable: "ResourceType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    directorUid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<int>(type: "int", nullable: false),
                    permissionIdToCRUD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    approvalDepartmentId = table.Column<int>(type: "int", nullable: false),
                    minApprovalGrade = table.Column<int>(type: "int", nullable: false),
                    permissionIdToCRUD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    Departmentid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.id);
                    table.ForeignKey(
                        name: "FK_RequestType_Department_Departmentid",
                        column: x => x.Departmentid,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    uid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    avatar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.uid);
                    table.ForeignKey(
                        name: "FK_User_Department_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    eventTypeId = table.Column<int>(type: "int", nullable: false),
                    reporterUid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    resouceUsingId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    postsId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    paticipantsUid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissionIdToCRUDPost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    startAt = table.Column<int>(type: "int", nullable: false),
                    endAt = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.id);
                    table.ForeignKey(
                        name: "FK_Event_EventType_eventTypeId",
                        column: x => x.eventTypeId,
                        principalTable: "EventType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_User_reporterUid",
                        column: x => x.reporterUid,
                        principalTable: "User",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    requesterUid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    requestType = table.Column<int>(type: "int", nullable: false),
                    reporterUid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    startAt = table.Column<int>(type: "int", nullable: false),
                    endAt = table.Column<int>(type: "int", nullable: false),
                    approvalStatus = table.Column<int>(type: "int", nullable: false),
                    decidedAt = table.Column<int>(type: "int", nullable: false),
                    decisionDetail = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.id);
                    table.ForeignKey(
                        name: "FK_Request_RequestType_requestType",
                        column: x => x.requestType,
                        principalTable: "RequestType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_User_reporterUid",
                        column: x => x.reporterUid,
                        principalTable: "User",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_User_requesterUid",
                        column: x => x.requesterUid,
                        principalTable: "User",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ResourceUsing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    resourceId = table.Column<int>(type: "int", nullable: false),
                    reporterUid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    borrowerUid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    startAt = table.Column<int>(type: "int", nullable: false),
                    endAt = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUsing", x => x.id);
                    table.ForeignKey(
                        name: "FK_ResourceUsing_Resource_resourceId",
                        column: x => x.resourceId,
                        principalTable: "Resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceUsing_User_borrowerUid",
                        column: x => x.borrowerUid,
                        principalTable: "User",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceUsing_User_reporterUid",
                        column: x => x.reporterUid,
                        principalTable: "User",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    postTypeId = table.Column<int>(type: "int", nullable: false),
                    creatorUid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    eventId = table.Column<int>(type: "int", nullable: true),
                    mentionUid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    likes = table.Column<int>(type: "int", nullable: false),
                    comments = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id);
                    table.ForeignKey(
                        name: "FK_Post_Event_eventId",
                        column: x => x.eventId,
                        principalTable: "Event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Post_PostType_postTypeId",
                        column: x => x.postTypeId,
                        principalTable: "PostType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_User_creatorUid",
                        column: x => x.creatorUid,
                        principalTable: "User",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostComment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    postId = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComment", x => x.id);
                    table.ForeignKey(
                        name: "FK_PostComment_Post_postId",
                        column: x => x.postId,
                        principalTable: "Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostComment_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostLike",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    postId = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLike", x => x.id);
                    table.ForeignKey(
                        name: "FK_PostLike_Post_postId",
                        column: x => x.postId,
                        principalTable: "Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostLike_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    size = table.Column<int>(type: "int", nullable: false),
                    PostCommentid = table.Column<int>(type: "int", nullable: true),
                    PostCommentid1 = table.Column<int>(type: "int", nullable: true),
                    Postid = table.Column<int>(type: "int", nullable: true),
                    Postid1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.id);
                    table.ForeignKey(
                        name: "FK_Files_PostComment_PostCommentid",
                        column: x => x.PostCommentid,
                        principalTable: "PostComment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Files_PostComment_PostCommentid1",
                        column: x => x.PostCommentid1,
                        principalTable: "PostComment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Files_Post_Postid",
                        column: x => x.Postid,
                        principalTable: "Post",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Files_Post_Postid1",
                        column: x => x.Postid1,
                        principalTable: "Post",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    documentTypeId = table.Column<int>(type: "int", nullable: false),
                    creatorUid = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fileid = table.Column<int>(type: "int", nullable: false),
                    createAt = table.Column<int>(type: "int", nullable: false),
                    updateAt = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.id);
                    table.ForeignKey(
                        name: "FK_Document_DocumentType_documentTypeId",
                        column: x => x.documentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_Files_fileid",
                        column: x => x.fileid,
                        principalTable: "Files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_User_creatorUid",
                        column: x => x.creatorUid,
                        principalTable: "User",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Department_directorUid",
                table: "Department",
                column: "directorUid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_creatorUid",
                table: "Document",
                column: "creatorUid");

            migrationBuilder.CreateIndex(
                name: "IX_Document_documentTypeId",
                table: "Document",
                column: "documentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_fileid",
                table: "Document",
                column: "fileid");

            migrationBuilder.CreateIndex(
                name: "IX_Event_eventTypeId",
                table: "Event",
                column: "eventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_reporterUid",
                table: "Event",
                column: "reporterUid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_PostCommentid",
                table: "Files",
                column: "PostCommentid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_PostCommentid1",
                table: "Files",
                column: "PostCommentid1");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Postid",
                table: "Files",
                column: "Postid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Postid1",
                table: "Files",
                column: "Postid1");

            migrationBuilder.CreateIndex(
                name: "IX_Post_creatorUid",
                table: "Post",
                column: "creatorUid");

            migrationBuilder.CreateIndex(
                name: "IX_Post_eventId",
                table: "Post",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_postTypeId",
                table: "Post",
                column: "postTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_postId",
                table: "PostComment",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_userId",
                table: "PostComment",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_postId",
                table: "PostLike",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_userId",
                table: "PostLike",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_reporterUid",
                table: "Request",
                column: "reporterUid");

            migrationBuilder.CreateIndex(
                name: "IX_Request_requesterUid",
                table: "Request",
                column: "requesterUid");

            migrationBuilder.CreateIndex(
                name: "IX_Request_requestType",
                table: "Request",
                column: "requestType");

            migrationBuilder.CreateIndex(
                name: "IX_RequestType_Departmentid",
                table: "RequestType",
                column: "Departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_resourceTypeId",
                table: "Resource",
                column: "resourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUsing_borrowerUid",
                table: "ResourceUsing",
                column: "borrowerUid");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUsing_reporterUid",
                table: "ResourceUsing",
                column: "reporterUid");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUsing_resourceId",
                table: "ResourceUsing",
                column: "resourceId");

            migrationBuilder.CreateIndex(
                name: "IX_User_departmentId",
                table: "User",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_directorUid",
                table: "Department",
                column: "directorUid",
                principalTable: "User",
                principalColumn: "uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_directorUid",
                table: "Department");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "PostLike");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "ResourceUsing");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "RequestType");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "PostComment");

            migrationBuilder.DropTable(
                name: "ResourceType");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "PostType");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
