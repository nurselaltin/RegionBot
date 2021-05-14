using Microsoft.EntityFrameworkCore.Migrations;

namespace RegionBot.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ilID = table.Column<int>(type: "int", nullable: true),
                    ilceID = table.Column<int>(type: "int", nullable: true),
                    bucakID = table.Column<int>(type: "int", nullable: true),
                    koyID = table.Column<int>(type: "int", nullable: true),
                    mahalleID = table.Column<int>(type: "int", nullable: true),
                    ServiceilID = table.Column<int>(type: "int", nullable: true),
                    ServiceilceID = table.Column<int>(type: "int", nullable: true),
                    ServicebucakID = table.Column<int>(type: "int", nullable: true),
                    ServicekoyID = table.Column<int>(type: "int", nullable: true),
                    ServicemahalleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
