using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeRate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SwitchToTemporalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "ExchangeRate")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<decimal>(
                name: "rate",
                table: "ExchangeRate",
                type: "decimal(18,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<string>(
                name: "pair",
                table: "ExchangeRate",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<string>(
                name: "last_update_source",
                table: "ExchangeRate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_update_on_utc",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "ExchangeRate",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AddColumn<DateTime>(
                name: "period_end",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AddColumn<DateTime>(
                name: "period_start",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "period_end",
                table: "ExchangeRate")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.DropColumn(
                name: "period_start",
                table: "ExchangeRate")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterTable(
                name: "ExchangeRate")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<decimal>(
                name: "rate",
                table: "ExchangeRate",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<string>(
                name: "pair",
                table: "ExchangeRate",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<string>(
                name: "last_update_source",
                table: "ExchangeRate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_update_on_utc",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "period_start");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "ExchangeRate",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "ExchangeRateHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "period_end")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "period_start");
        }
    }
}
