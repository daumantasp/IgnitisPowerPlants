using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IgnitisPowerPlants.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPowerPlantsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PowerPlants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Power = table.Column<decimal>(type: "decimal(6,1)", nullable: false),
                    ValidFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    ValidTo = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerPlants", x => x.Id);
                    table.CheckConstraint("CK_PowerPlants_Owner", "[Owner] LIKE '% %' AND [Owner] NOT LIKE '%  %' AND [Owner] NOT LIKE '%[0-9]%'");
                    table.CheckConstraint("CK_PowerPlants_Power", "[Power] >= 0.0 AND [Power] <= 200.0");
                    table.CheckConstraint("CK_PowerPlants_ValidFrom_ValidTo", "[ValidTo] IS NULL OR [ValidFrom] < [ValidTo]");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PowerPlants");
        }
    }
}
