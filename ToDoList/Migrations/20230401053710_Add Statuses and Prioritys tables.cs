using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusesandPrioritystables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "ToDoLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ToDoLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Prioritys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioritys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_PriorityId",
                table: "ToDoLists",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_StatusId",
                table: "ToDoLists",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_Prioritys_PriorityId",
                table: "ToDoLists",
                column: "PriorityId",
                principalTable: "Prioritys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_Statuses_StatusId",
                table: "ToDoLists",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_Prioritys_PriorityId",
                table: "ToDoLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_Statuses_StatusId",
                table: "ToDoLists");

            migrationBuilder.DropTable(
                name: "Prioritys");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_PriorityId",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_StatusId",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ToDoLists");
        }
    }
}
