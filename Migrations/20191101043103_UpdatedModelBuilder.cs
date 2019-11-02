using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryRazorPage.Migrations
{
    public partial class UpdatedModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Literally a Big Gun");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Literally a Gun");
        }
    }
}
