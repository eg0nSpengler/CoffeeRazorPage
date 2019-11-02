using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryRazorPage.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageFileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ImageFileName", "Name", "Price" },
                values: new object[] { 1, "For those who need more than a little pick-me-up", "bigolcup.jpg", "Big Ol' Cuppa", 8.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ImageFileName", "Name", "Price" },
                values: new object[] { 2, "In case you need to cut back a little", "smallolcup.jpg", "Tiny Ol' Cuppa", 4.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ImageFileName", "Name", "Price" },
                values: new object[] { 3, "What the!? How did this get here?", "agun.jpg", "Literally a Gun", 999.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
