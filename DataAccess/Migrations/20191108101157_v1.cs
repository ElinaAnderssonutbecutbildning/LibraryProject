using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookShelfAisles",
                columns: table => new
                {
                    BookshelfAisleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookshelfAisleNumber = table.Column<int>(nullable: false),
                    ShelfID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShelfAisles", x => x.BookshelfAisleID);
                });

            migrationBuilder.CreateTable(
                name: "LoanTimes",
                columns: table => new
                {
                    LoanTimeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FindAvailableBooksID = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTimes", x => x.LoanTimeID);
                });

            migrationBuilder.CreateTable(
                name: "Shelfs",
                columns: table => new
                {
                    ShelfID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelfNumber = table.Column<int>(nullable: false),
                    BookshelfAisleNumber = table.Column<int>(nullable: false),
                    BookshelfAisleID = table.Column<int>(nullable: false),
                    GetShelfByShelfNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelfs", x => x.ShelfID);
                    table.ForeignKey(
                        name: "FK_Shelfs_BookShelfAisles_BookshelfAisleID",
                        column: x => x.BookshelfAisleID,
                        principalTable: "BookShelfAisles",
                        principalColumn: "BookshelfAisleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(nullable: true),
                    BookPrice = table.Column<int>(nullable: false),
                    ShelfID = table.Column<int>(nullable: false),
                    FindAvailableBooksID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Book_Shelfs_ShelfID",
                        column: x => x.ShelfID,
                        principalTable: "Shelfs",
                        principalColumn: "ShelfID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FindAvailableBooks",
                columns: table => new
                {
                    FindAvailableBooksID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    CustormerName = table.Column<string>(nullable: true),
                    LoanTimeID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false),
                    BookID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindAvailableBooks", x => x.FindAvailableBooksID);
                    table.ForeignKey(
                        name: "FK_FindAvailableBooks_Book_BookID1",
                        column: x => x.BookID1,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FindAvailableBooks_LoanTimes_LoanTimeID",
                        column: x => x.LoanTimeID,
                        principalTable: "LoanTimes",
                        principalColumn: "LoanTimeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomersName = table.Column<string>(nullable: true),
                    CustomersAddress = table.Column<string>(nullable: true),
                    CustomersDateOfBirthYYYYMMDD = table.Column<string>(nullable: true),
                    MoneyDebtID = table.Column<int>(nullable: false),
                    FindAvailableBooksID = table.Column<int>(nullable: false),
                    FindAvailableBooksID1 = table.Column<int>(nullable: true),
                    BookLoansID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_FindAvailableBooks_FindAvailableBooksID1",
                        column: x => x.FindAvailableBooksID1,
                        principalTable: "FindAvailableBooks",
                        principalColumn: "FindAvailableBooksID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    BookLoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GetBookLoanByBookLoanID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => x.BookLoanID);
                    table.ForeignKey(
                        name: "FK_BookLoans_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoans_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyDebts",
                columns: table => new
                {
                    MoneyDebtID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoneyDebtNumber = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    GetActiveMoneyDebtByCustomer = table.Column<int>(nullable: false),
                    GetActiveMoneyDebt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyDebts", x => x.MoneyDebtID);
                    table.ForeignKey(
                        name: "FK_MoneyDebts_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_ShelfID",
                table: "Book",
                column: "ShelfID");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_BookID",
                table: "BookLoans",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_CustomerID",
                table: "BookLoans",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FindAvailableBooksID1",
                table: "Customer",
                column: "FindAvailableBooksID1");

            migrationBuilder.CreateIndex(
                name: "IX_FindAvailableBooks_BookID1",
                table: "FindAvailableBooks",
                column: "BookID1");

            migrationBuilder.CreateIndex(
                name: "IX_FindAvailableBooks_LoanTimeID",
                table: "FindAvailableBooks",
                column: "LoanTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyDebts_CustomerID",
                table: "MoneyDebts",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Shelfs_BookshelfAisleID",
                table: "Shelfs",
                column: "BookshelfAisleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoans");

            migrationBuilder.DropTable(
                name: "MoneyDebts");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "FindAvailableBooks");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "LoanTimes");

            migrationBuilder.DropTable(
                name: "Shelfs");

            migrationBuilder.DropTable(
                name: "BookShelfAisles");
        }
    }
}
