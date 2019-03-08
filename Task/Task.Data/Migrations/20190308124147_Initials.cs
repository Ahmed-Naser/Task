using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task.Data.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NaseejProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemCount = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrices = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaseejProducts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaseejProducts");
        }
    }
}
