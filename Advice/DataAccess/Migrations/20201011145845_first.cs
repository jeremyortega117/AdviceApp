using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPT_NAME = table.Column<int>(maxLength: 100, nullable: false),
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
                        name: "FK_Review_Department",
                        column: x => x.DEPT_ID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCOUNT_ID = table.Column<int>(nullable: false),
                    CONVERSATION_TYPE = table.Column<int>(nullable: false),
                    DEPT_ID = table.Column<int>(nullable: false),
                    ACCESS_LEVEL = table.Column<int>(nullable: false),
                    AccountsID = table.Column<int>(nullable: true),
                    DepartmentsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conversations_Accounts_AccountsID",
                        column: x => x.AccountsID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversations_Departments_DepartmentsID",
                        column: x => x.DepartmentsID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_DEPT_ID",
                table: "Accounts",
                column: "DEPT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_AccountsID",
                table: "Conversations",
                column: "AccountsID");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_DepartmentsID",
                table: "Conversations",
                column: "DepartmentsID");

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
