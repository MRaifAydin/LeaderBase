using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaderBase.DataAccess.Migrations
{
    public partial class authEntitiesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserOperationClaims",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserOperationClaims",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserOperationClaims",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "UserOperationClaims",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "UserOperationClaims",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OperationClaims",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OperationClaims",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OperationClaims",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "OperationClaims",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "OperationClaims",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "OperationClaims");
        }
    }
}
