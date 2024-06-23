using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeRate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_row_version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "version",
                table: "ExchangeRate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "version",
                table: "ExchangeRate",
                type: "bigint",
                rowVersion: true,
                nullable: false,
                defaultValue: 0L);
        }
    }
}
