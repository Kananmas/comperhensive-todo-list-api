using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comperhensive_todo_list_api.Migrations
{
    /// <inheritdoc />
    public partial class cascadedelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_todos_UserId",
                table: "todos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_steps_TodoId",
                table: "steps",
                column: "TodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_steps_todos_TodoId",
                table: "steps",
                column: "TodoId",
                principalTable: "todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_todos_users_UserId",
                table: "todos",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_steps_todos_TodoId",
                table: "steps");

            migrationBuilder.DropForeignKey(
                name: "FK_todos_users_UserId",
                table: "todos");

            migrationBuilder.DropIndex(
                name: "IX_todos_UserId",
                table: "todos");

            migrationBuilder.DropIndex(
                name: "IX_steps_TodoId",
                table: "steps");
        }
    }
}
