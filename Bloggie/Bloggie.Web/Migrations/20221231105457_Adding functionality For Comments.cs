using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingfunctionalityForComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogPostLike_BlogPosts_BlogPostId",
                table: "blogPostLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPostLike",
                table: "blogPostLike");

            migrationBuilder.RenameTable(
                name: "blogPostLike",
                newName: "BlogPostLike");

            migrationBuilder.RenameIndex(
                name: "IX_blogPostLike_BlogPostId",
                table: "BlogPostLike",
                newName: "IX_BlogPostLike_BlogPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostLike",
                table: "BlogPostLike",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BlogPostComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostComment_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComment_BlogPostId",
                table: "BlogPostComment",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostLike_BlogPosts_BlogPostId",
                table: "BlogPostLike",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostLike_BlogPosts_BlogPostId",
                table: "BlogPostLike");

            migrationBuilder.DropTable(
                name: "BlogPostComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostLike",
                table: "BlogPostLike");

            migrationBuilder.RenameTable(
                name: "BlogPostLike",
                newName: "blogPostLike");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostLike_BlogPostId",
                table: "blogPostLike",
                newName: "IX_blogPostLike_BlogPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPostLike",
                table: "blogPostLike",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostLike_BlogPosts_BlogPostId",
                table: "blogPostLike",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
