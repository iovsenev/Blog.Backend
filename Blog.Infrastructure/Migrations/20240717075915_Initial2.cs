using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_articles_user_entity_author_id",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_user_entity_author_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_users_roles_role_id",
                table: "users");

            migrationBuilder.AddColumn<string[]>(
                name: "permissions",
                table: "roles",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddForeignKey(
                name: "fk_articles_users_author_id",
                table: "articles",
                column: "author_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_users_author_id",
                table: "comments",
                column: "author_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_role_entity_role_id",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_articles_users_author_id",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_users_author_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_users_role_entity_role_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "permissions",
                table: "roles");

            migrationBuilder.AddForeignKey(
                name: "fk_articles_user_entity_author_id",
                table: "articles",
                column: "author_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_user_entity_author_id",
                table: "comments",
                column: "author_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
