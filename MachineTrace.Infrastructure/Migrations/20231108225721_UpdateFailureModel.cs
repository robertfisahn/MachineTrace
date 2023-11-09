using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineTrace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFailureModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Failures",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Failures");
        }
    }
}
