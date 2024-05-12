using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using RFLOT.Domain.Report.ValueObjects;

#nullable disable

namespace RFLOT.Infrastructure.Report.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPlane = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    DateTimeStart = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateTimeFinish = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StatusReport = table.Column<bool>(type: "boolean", nullable: false),
                    ZoneReports = table.Column<IEnumerable<ZoneReport>>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
