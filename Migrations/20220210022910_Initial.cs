using Microsoft.EntityFrameworkCore.Migrations;

namespace SevenHabitsTodoApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    DueDate = table.Column<string>(nullable: true),
                    Quadrant = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 3, 1, false, "2022-02-11", 4, "Play Fortnite" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 5, 1, false, "2022-02-09", 3, "Call Mom back" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 10, 1, false, "2022-02-11", 3, "Go grocery shopping" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 1, 2, false, "2022-02-09", 1, "Finish 455 MLR Project" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 2, 2, false, "2022-02-11", 2, "Wash Dishes" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 7, 2, false, "2022-02-16", 2, "Apply for graduation" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 9, 2, false, "2022-02-09", 1, "Finish Project 1" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 6, 3, false, "2022-02-12", 1, "Deliver new report to manager" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 4, 4, true, "2022-02-06", 2, "Do Ministering" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 8, 4, false, "2022-02-13", 2, "Go to church" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryID",
                table: "Responses",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
