using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cascade.Api.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AuthorLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Citation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookId", "AuthorFirstName", "AuthorLastName", "Citation", "Price", "Publisher", "Title" },
                values: new object[,]
                {
                    { new Guid("334bfe27-12e9-4131-b891-84b1d29f9f81"), "Marijn", "Haverbeke", "{\"AuthorLastName\":\"Simpson\",\"AuthorFirstName\":\"Kyle\",\"Title\":\"You Don\\u0027t Know JS Yet\",\"TitleOfContainer\":\"You Don\\u0027t Know JS Yet Container\",\"Publisher\":\"No Starch Press\",\"PublicationDate\":\"2018\",\"PageNumbers\":\"103\",\"VolumeNo\":\"2\",\"Url\":\"https://example.com\"}", 47m, "No Starch Press", "Eloquent JavaScript, Third Edition" },
                    { new Guid("6628fec1-8c1b-4129-81cc-0b239e54a65b"), "Nicolás", "Bevacqua", "{\"AuthorLastName\":\"Chacon\",\"AuthorFirstName\":\"Scott\",\"Title\":\"Pro Git\",\"TitleOfContainer\":\"Pro Git Container\",\"Publisher\":\"O\\u0027Reilly Media\",\"PublicationDate\":\"February 1935\",\"PageNumbers\":\"10-12\",\"VolumeNo\":\"V\",\"Url\":\"https://example.com\"}", 33m, "O'Reilly Media", "Practical Modern JavaScript" },
                    { new Guid("8a8e5b09-aa66-44f3-a27f-af2ea5ca6b5b"), "Nicholas C.", "Zakas", "{\"AuthorLastName\":\"Sadowski\",\"AuthorFirstName\":\"Caitlin\",\"Title\":\"Rethinking Productivity in Software Engineering\",\"TitleOfContainer\":\"Rethinking Productivity in Software Engineering Contanier\",\"Publisher\":\"Independently published\",\"PublicationDate\":\"2018\",\"PageNumbers\":\"12,14\",\"VolumeNo\":\"III\",\"Url\":\"https://example.com\"}", 35m, "Independently published", "Understanding ECMAScript 6" },
                    { new Guid("ab37a236-1b48-4fa5-839d-194a5b7c2bcf"), "Axel", "Rauschmayer", "{\"AuthorLastName\":\"Chacon\",\"AuthorFirstName\":\"Scott\",\"Title\":\"Pro Git\",\"TitleOfContainer\":\"Pro Git Container\",\"Publisher\":\"O\\u0027Reilly Media\",\"PublicationDate\":\"February 1935\",\"PageNumbers\":\"10-12\",\"VolumeNo\":\"V\",\"Url\":\"https://example.com\"}", 46m, "Apress; 2nd edition", "Speaking JavaScript" },
                    { new Guid("35116a3a-9f2a-48da-b08e-81d7d4f81a0d"), "Addy", "Osmani", "{\"AuthorLastName\":\"Sadowski\",\"AuthorFirstName\":\"Caitlin\",\"Title\":\"Rethinking Productivity in Software Engineering\",\"TitleOfContainer\":\"Rethinking Productivity in Software Engineering Contanier\",\"Publisher\":\"Independently published\",\"PublicationDate\":\"2018\",\"PageNumbers\":\"12,14\",\"VolumeNo\":\"III\",\"Url\":\"https://example.com\"}", 25m, "Apress", "Learning JavaScript Design Patterns" }
                });


            migrationBuilder.Sql(@"CREATE OR ALTER PROC [dbo].[spGetOrderedByPublisherAuthorTitle] 
                AS
                BEGIN
	                SET NOCOUNT ON;
	                SELECT * FROM Book
	                ORDER BY Publisher, AuthorLastName, AuthorFirstName, Title
                END");

            migrationBuilder.Sql(@"CREATE OR ALTER PROC [dbo].[spGetOrderedByAuthorTitle] 
                AS
                BEGIN
	                SET NOCOUNT ON;
	                SELECT * FROM Book 
	                ORDER BY AuthorLastName, AuthorFirstName, Title
                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
