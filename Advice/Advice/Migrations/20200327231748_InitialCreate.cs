using Microsoft.EntityFrameworkCore.Migrations;

namespace Advice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: true),
                    QuestionType = table.Column<string>(nullable: true),
                    Account_ID = table.Column<int>(nullable: true),
                    Upvotes = table.Column<int>(nullable: false),
                    Visited = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Questions_Accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answers_ = table.Column<string>(nullable: false),
                    Question_ID = table.Column<int>(maxLength: 1000, nullable: false),
                    Account_ID = table.Column<int>(nullable: false),
                    Upvotes = table.Column<int>(nullable: false),
                    Visited = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answers_Accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_Question_ID",
                        column: x => x.Question_ID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "Email", "Password", "Username" },
                values: new object[] { 1, "greg@mail.com", "pass@word", "gregory" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "Email", "Password", "Username" },
                values: new object[] { 2, "paul@mail.com", "pass@word1", "paul" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "Email", "Password", "Username" },
                values: new object[] { 3, "samantha@mail.com", "pass@word2", "samantha" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "ID", "Account_ID", "Question", "QuestionType", "Upvotes", "Visited" },
                values: new object[] { 1, 1, "How to make grilled cheese", "cooking", 0, 0 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "ID", "Account_ID", "Question", "QuestionType", "Upvotes", "Visited" },
                values: new object[] { 2, 1, "How to make PB&J", "cooking", 0, 0 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "ID", "Account_ID", "Answers_", "Question_ID", "Upvotes", "Visited" },
                values: new object[] { 1, 1, "butter the outside of two pieces of bread and place a slice of cheese in the middle and cook on stove for 3 minutes on each side.", 1, 0, 0 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "ID", "Account_ID", "Answers_", "Question_ID", "Upvotes", "Visited" },
                values: new object[] { 2, 3, "Place PB and Jelly in between two pieces of bread.", 1, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Account_ID",
                table: "Answers",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Question_ID",
                table: "Answers",
                column: "Question_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Account_ID",
                table: "Questions",
                column: "Account_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
