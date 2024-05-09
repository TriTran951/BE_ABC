﻿// <auto-generated />
using System;
using BE_ABC.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BE_ABC.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BE_ABC.Models.ErdModel.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("directorUid")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("name")
                        .HasColumnType("int");

                    b.Property<string>("permissionIdToCRUD")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("directorUid")
                        .IsUnique();

                    b.ToTable("Department");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.Post", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("comments")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("creatorUid")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("eventId")
                        .HasColumnType("int");

                    b.Property<int>("likes")
                        .HasColumnType("int");

                    b.Property<string>("mentionUid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("postTypeId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("creatorUid");

                    b.HasIndex("eventId");

                    b.HasIndex("postTypeId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.PostComment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<int>("postId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("id");

                    b.HasIndex("postId");

                    b.HasIndex("userId");

                    b.ToTable("PostComment");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.PostLike", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<int>("postId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("id");

                    b.HasIndex("postId");

                    b.HasIndex("userId");

                    b.ToTable("PostLike");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.PostType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUD")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUDPost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("PostType");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.Resource", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isFree")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("resourceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("resourceTypeId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Document", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("creatorUid")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("documentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("fileid")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("creatorUid");

                    b.HasIndex("documentTypeId");

                    b.HasIndex("fileid");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.DocumentType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUD")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUDDocument")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("DocumentType");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("endAt")
                        .HasColumnType("int");

                    b.Property<int>("eventTypeId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("paticipantsUid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUDPost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("postsId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("reporterUid")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("resouceUsingId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("startAt")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("eventTypeId");

                    b.HasIndex("reporterUid");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.EventType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUD")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUDEvent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Files", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("PostCommentid")
                        .HasColumnType("int");

                    b.Property<int?>("PostCommentid1")
                        .HasColumnType("int");

                    b.Property<int?>("Postid")
                        .HasColumnType("int");

                    b.Property<int?>("Postid1")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("size")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("PostCommentid");

                    b.HasIndex("PostCommentid1");

                    b.HasIndex("Postid");

                    b.HasIndex("Postid1");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Permission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("action")
                        .HasColumnType("int");

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<bool>("isPretected")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("minGrade")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Request", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("approvalStatus")
                        .HasColumnType("int");

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<int>("decidedAt")
                        .HasColumnType("int");

                    b.Property<string>("decisionDetail")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("endAt")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("reporterUid")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("requestType")
                        .HasColumnType("int");

                    b.Property<string>("requesterUid")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("startAt")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("reporterUid");

                    b.HasIndex("requestType");

                    b.HasIndex("requesterUid");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.RequestType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Departmentid")
                        .HasColumnType("int");

                    b.Property<int>("approvalDepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("minApprovalGrade")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUD")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Departmentid");

                    b.ToTable("RequestType");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.ResourceType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUD")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUDResource")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("permissionIdToCRUDResourceUsing")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ResourceType");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.ResourceUsing", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("borrowerUid")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<int>("endAt")
                        .HasColumnType("int");

                    b.Property<string>("reporterUid")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("resourceId")
                        .HasColumnType("int");

                    b.Property<int>("startAt")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("borrowerUid");

                    b.HasIndex("reporterUid");

                    b.HasIndex("resourceId");

                    b.ToTable("ResourceUsing");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.User", b =>
                {
                    b.Property<string>("uid")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("createAt")
                        .HasColumnType("int");

                    b.Property<int?>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("grade")
                        .HasColumnType("int");

                    b.Property<string>("permissionIdToCRUD")
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("updateAt")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("uid");

                    b.HasIndex("departmentId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.Department", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModels.User", "User")
                        .WithOne()
                        .HasForeignKey("BE_ABC.Models.ErdModel.Department", "directorUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.Post", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModels.User", "User")
                        .WithMany()
                        .HasForeignKey("creatorUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModels.Event", "Event")
                        .WithMany("Post")
                        .HasForeignKey("eventId");

                    b.HasOne("BE_ABC.Models.ErdModel.PostType", "PostType")
                        .WithMany("Post")
                        .HasForeignKey("postTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("PostType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.PostComment", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModel.Post", "Post")
                        .WithMany("PostComment")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModels.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.PostLike", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModel.Post", "Post")
                        .WithMany("PostLike")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModels.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.Resource", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModels.ResourceType", "ResourceType")
                        .WithMany()
                        .HasForeignKey("resourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResourceType");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Document", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModels.User", "User")
                        .WithMany()
                        .HasForeignKey("creatorUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModels.DocumentType", "DocumentType")
                        .WithMany("Document")
                        .HasForeignKey("documentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModels.Files", "file")
                        .WithMany()
                        .HasForeignKey("fileid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("User");

                    b.Navigation("file");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Event", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModels.EventType", "EventType")
                        .WithMany("Event")
                        .HasForeignKey("eventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModels.User", "User")
                        .WithMany()
                        .HasForeignKey("reporterUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Files", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModel.PostComment", null)
                        .WithMany("file")
                        .HasForeignKey("PostCommentid");

                    b.HasOne("BE_ABC.Models.ErdModel.PostComment", null)
                        .WithMany("images")
                        .HasForeignKey("PostCommentid1");

                    b.HasOne("BE_ABC.Models.ErdModel.Post", null)
                        .WithMany("files")
                        .HasForeignKey("Postid");

                    b.HasOne("BE_ABC.Models.ErdModel.Post", null)
                        .WithMany("images")
                        .HasForeignKey("Postid1");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Request", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModels.User", "Reporter")
                        .WithMany()
                        .HasForeignKey("reporterUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModels.RequestType", "RequestType")
                        .WithMany("Request")
                        .HasForeignKey("requestType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModels.User", "Requester")
                        .WithMany()
                        .HasForeignKey("requesterUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reporter");

                    b.Navigation("RequestType");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.RequestType", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModel.Department", "Department")
                        .WithMany("RequestType")
                        .HasForeignKey("Departmentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.ResourceUsing", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModels.User", "Borrower")
                        .WithMany()
                        .HasForeignKey("borrowerUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModels.User", "Reporter")
                        .WithMany()
                        .HasForeignKey("reporterUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ABC.Models.ErdModel.Resource", "Resource")
                        .WithMany("ResourceUsing")
                        .HasForeignKey("resourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Borrower");

                    b.Navigation("Reporter");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.User", b =>
                {
                    b.HasOne("BE_ABC.Models.ErdModel.Department", "Department")
                        .WithMany()
                        .HasForeignKey("departmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.Department", b =>
                {
                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.Post", b =>
                {
                    b.Navigation("PostComment");

                    b.Navigation("PostLike");

                    b.Navigation("files");

                    b.Navigation("images");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.PostComment", b =>
                {
                    b.Navigation("file");

                    b.Navigation("images");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.PostType", b =>
                {
                    b.Navigation("Post");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModel.Resource", b =>
                {
                    b.Navigation("ResourceUsing");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.DocumentType", b =>
                {
                    b.Navigation("Document");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.Event", b =>
                {
                    b.Navigation("Post");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.EventType", b =>
                {
                    b.Navigation("Event");
                });

            modelBuilder.Entity("BE_ABC.Models.ErdModels.RequestType", b =>
                {
                    b.Navigation("Request");
                });
#pragma warning restore 612, 618
        }
    }
}
