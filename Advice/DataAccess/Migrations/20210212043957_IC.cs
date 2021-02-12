using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class IC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPT_NAME = table.Column<string>(maxLength: 100, nullable: false),
                    DEPT_ACCESS = table.Column<int>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FNAME = table.Column<string>(maxLength: 100, nullable: false),
                    LNAME = table.Column<string>(maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 100, nullable: false),
                    ACCESS_LEVEL = table.Column<int>(maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(maxLength: 100, nullable: false),
                    USERNAME = table.Column<string>(maxLength: 100, nullable: false),
                    DEPT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_Departments_DEPT_ID",
                        column: x => x.DEPT_ID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCOUNT_ID = table.Column<int>(nullable: false),
                    CONVERSATION_TYPE = table.Column<int>(maxLength: 100, nullable: false),
                    ACCESS_LEVEL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conversations_Accounts_ACCOUNT_ID",
                        column: x => x.ACCOUNT_ID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONVERSATION_ID = table.Column<int>(nullable: false),
                    DEPT_ID = table.Column<int>(nullable: false),
                    ACCOUNT_ID = table.Column<int>(nullable: false),
                    DATE_MADE = table.Column<DateTime>(nullable: false),
                    MESSAGE = table.Column<byte[]>(nullable: true),
                    MESSAGE_TYPE = table.Column<string>(nullable: true),
                    TYPE = table.Column<string>(nullable: true),
                    FILE_LOCATION = table.Column<string>(nullable: true),
                    KEYWORDS = table.Column<string>(nullable: true),
                    UPVOTES = table.Column<int>(nullable: false),
                    VIEWS = table.Column<int>(nullable: false),
                    READ_ACCESS = table.Column<int>(nullable: false),
                    WRITE_ACCESS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_Accounts_ACCOUNT_ID",
                        column: x => x.ACCOUNT_ID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_CONVERSATION_ID",
                        column: x => x.CONVERSATION_ID,
                        principalTable: "Conversations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Departments_DEPT_ID",
                        column: x => x.DEPT_ID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "DEPT_ACCESS", "DEPT_NAME" },
                values: new object[] { 1, 9001, "Fun Zone" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "DEPT_ACCESS", "DEPT_NAME" },
                values: new object[] { 2, 0, "Stranger Danger" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "ACCESS_LEVEL", "DEPT_ID", "EMAIL", "FNAME", "LNAME", "PASSWORD", "PHONE", "USERNAME" },
                values: new object[] { 1, 17, 1, "nickfurgerson@email.com", "Nick", "Furgerson", "BLESSEDONE", "1(138)789-2123", "soccerboy" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "ACCESS_LEVEL", "DEPT_ID", "EMAIL", "FNAME", "LNAME", "PASSWORD", "PHONE", "USERNAME" },
                values: new object[] { 2, 1, 2, "jaylance@email.com", "Jay", "Lance", "firedup", "765-5432", "rayrance" });

            migrationBuilder.InsertData(
                table: "Conversations",
                columns: new[] { "ID", "ACCESS_LEVEL", "ACCOUNT_ID", "CONVERSATION_TYPE" },
                values: new object[] { 1, 10, 1, 1 });

            migrationBuilder.InsertData(
                table: "Conversations",
                columns: new[] { "ID", "ACCESS_LEVEL", "ACCOUNT_ID", "CONVERSATION_TYPE" },
                values: new object[] { 2, 5, 1, 2 });

            migrationBuilder.InsertData(
                table: "Conversations",
                columns: new[] { "ID", "ACCESS_LEVEL", "ACCOUNT_ID", "CONVERSATION_TYPE" },
                values: new object[] { 3, 3, 2, 3 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "ID", "ACCOUNT_ID", "CONVERSATION_ID", "DATE_MADE", "DEPT_ID", "FILE_LOCATION", "KEYWORDS", "MESSAGE", "MESSAGE_TYPE", "READ_ACCESS", "TYPE", "UPVOTES", "VIEWS", "WRITE_ACCESS" },
                values: new object[] { 1, 1, 1, new DateTime(2021, 2, 11, 22, 39, 56, 904, DateTimeKind.Local).AddTicks(5937), 1, "C:\\Users\\JPOje\\OneDrive\\Documents\\CODE\\PROJECTS\\Advice App\\Notes", "BLESSINGS", new byte[] { 0, 1, 2 }, ".txt", 99, "NOTE", 100, 117, 4 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "ID", "ACCOUNT_ID", "CONVERSATION_ID", "DATE_MADE", "DEPT_ID", "FILE_LOCATION", "KEYWORDS", "MESSAGE", "MESSAGE_TYPE", "READ_ACCESS", "TYPE", "UPVOTES", "VIEWS", "WRITE_ACCESS" },
                values: new object[] { 2, 2, 2, new DateTime(2021, 2, 11, 22, 39, 56, 907, DateTimeKind.Local).AddTicks(3403), 2, "C:\\Users\\JPOje\\OneDrive\\Documents\\CODE\\PROJECTS\\Advice App\\Notes", "funny", new byte[] { 1, 2, 3 }, ".png", 9, "QUESTION", 56, 70, 5 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "ID", "ACCOUNT_ID", "CONVERSATION_ID", "DATE_MADE", "DEPT_ID", "FILE_LOCATION", "KEYWORDS", "MESSAGE", "MESSAGE_TYPE", "READ_ACCESS", "TYPE", "UPVOTES", "VIEWS", "WRITE_ACCESS" },
                values: new object[] { 3, 2, 2, new DateTime(2021, 2, 11, 22, 39, 56, 907, DateTimeKind.Local).AddTicks(3683), 2, "C:\\Users\\JPOje\\OneDrive\\Documents\\CODE\\PROJECTS\\Advice App\\Notes", "funny", new byte[] { 2, 3, 4 }, ".png", 9, "ANSWER", 7, 12, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_DEPT_ID",
                table: "Accounts",
                column: "DEPT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_ACCOUNT_ID",
                table: "Conversations",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ACCOUNT_ID",
                table: "Messages",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CONVERSATION_ID",
                table: "Messages",
                column: "CONVERSATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DEPT_ID",
                table: "Messages",
                column: "DEPT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
