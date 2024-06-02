using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSuite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialmigrationtoProductionEnvupdatingtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coumtries_States_StateId",
                table: "Coumtries");

            migrationBuilder.DropForeignKey(
                name: "FK_Coumtries_States_StateId1",
                table: "Coumtries");

            migrationBuilder.DropIndex(
                name: "IX_Coumtries_StateId",
                table: "Coumtries");

            migrationBuilder.DropIndex(
                name: "IX_Coumtries_StateId1",
                table: "Coumtries");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Coumtries");

            migrationBuilder.DropColumn(
                name: "StateId1",
                table: "Coumtries");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Districts",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Districts",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Districts",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Districts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coumtries",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Coumtries",
                newName: "country_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Companies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegisterName",
                table: "Companies",
                newName: "register_name");

            migrationBuilder.RenameColumn(
                name: "FantasyName",
                table: "Companies",
                newName: "fantasy_name");

            migrationBuilder.RenameColumn(
                name: "CNPJNumber",
                table: "Companies",
                newName: "cnpj_number");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Addresses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Addresses",
                newName: "contact_name");

            migrationBuilder.RenameColumn(
                name: "AddressLine",
                table: "Addresses",
                newName: "address_line");

            migrationBuilder.AlterColumn<bool>(
                name: "IsZipCodeEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsShippingEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDistrictEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCityEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsBillingEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Districts",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Districts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Districts",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Districts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Coumtries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "country_name",
                table: "Coumtries",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Companies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "register_name",
                table: "Companies",
                newName: "RegisterName");

            migrationBuilder.RenameColumn(
                name: "fantasy_name",
                table: "Companies",
                newName: "FantasyName");

            migrationBuilder.RenameColumn(
                name: "cnpj_number",
                table: "Companies",
                newName: "CNPJNumber");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Addresses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "contact_name",
                table: "Addresses",
                newName: "ContactName");

            migrationBuilder.RenameColumn(
                name: "address_line",
                table: "Addresses",
                newName: "AddressLine");

            migrationBuilder.AlterColumn<bool>(
                name: "IsZipCodeEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsShippingEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDistrictEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCityEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsBillingEnabled",
                table: "Coumtries",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Coumtries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StateId1",
                table: "Coumtries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coumtries_StateId",
                table: "Coumtries",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Coumtries_StateId1",
                table: "Coumtries",
                column: "StateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Coumtries_States_StateId",
                table: "Coumtries",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coumtries_States_StateId1",
                table: "Coumtries",
                column: "StateId1",
                principalTable: "States",
                principalColumn: "Id");
        }
    }
}
