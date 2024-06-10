using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSuite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialmigrationtoDEVEnv8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Addresses_AddressId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Districts_DistrictId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Coumtries_States_StateId",
                table: "Coumtries");

            migrationBuilder.DropForeignKey(
                name: "FK_Coumtries_States_StateId1",
                table: "Coumtries");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Addresses_AddressId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Cities_CityId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Coumtries_CountryId",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coumtries",
                table: "Coumtries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "mscore_states");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "mscore_medias");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "mscore_districts");

            migrationBuilder.RenameTable(
                name: "Coumtries",
                newName: "mscore_coumtries");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "mscore_companies");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "mscore_cities");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "mscore_addresses");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                table: "mscore_states",
                newName: "IX_mscore_states_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_States_CityId",
                table: "mscore_states",
                newName: "IX_mscore_states_CityId");

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "mscore_medias",
                newName: "caption");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "mscore_medias",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MediaType",
                table: "mscore_medias",
                newName: "media_type");

            migrationBuilder.RenameColumn(
                name: "FileSize",
                table: "mscore_medias",
                newName: "file_size");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "mscore_medias",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "mscore_districts",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "mscore_districts",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "mscore_districts",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "mscore_districts",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_CityId",
                table: "mscore_districts",
                newName: "IX_mscore_districts_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_AddressId",
                table: "mscore_districts",
                newName: "IX_mscore_districts_AddressId");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "mscore_coumtries",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "mscore_coumtries",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsZipCodeEnabled",
                table: "mscore_coumtries",
                newName: "is_zip_code_enabled");

            migrationBuilder.RenameColumn(
                name: "IsShippingEnabled",
                table: "mscore_coumtries",
                newName: "is_shipping_enabled");

            migrationBuilder.RenameColumn(
                name: "IsDistrictEnabled",
                table: "mscore_coumtries",
                newName: "is_dDistrict_enabled");

            migrationBuilder.RenameColumn(
                name: "IsCityEnabled",
                table: "mscore_coumtries",
                newName: "is_city_enabled");

            migrationBuilder.RenameColumn(
                name: "IsBillingEnabled",
                table: "mscore_coumtries",
                newName: "is_billing_enabled");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "mscore_coumtries",
                newName: "country_name");

            migrationBuilder.RenameIndex(
                name: "IX_Coumtries_StateId1",
                table: "mscore_coumtries",
                newName: "IX_mscore_coumtries_StateId1");

            migrationBuilder.RenameIndex(
                name: "IX_Coumtries_StateId",
                table: "mscore_coumtries",
                newName: "IX_mscore_coumtries_StateId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "mscore_companies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegisterName",
                table: "mscore_companies",
                newName: "register_name");

            migrationBuilder.RenameColumn(
                name: "FantasyName",
                table: "mscore_companies",
                newName: "fantasy_name");

            migrationBuilder.RenameColumn(
                name: "CNPJNumber",
                table: "mscore_companies",
                newName: "cnpj_number");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "mscore_cities",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "mscore_cities",
                newName: "city_name");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_StateId",
                table: "mscore_cities",
                newName: "IX_mscore_cities_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_DistrictId",
                table: "mscore_cities",
                newName: "IX_mscore_cities_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_AddressId",
                table: "mscore_cities",
                newName: "IX_mscore_cities_AddressId");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "mscore_addresses",
                newName: "contactName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "mscore_addresses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "AddressLine",
                table: "mscore_addresses",
                newName: "address_line");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_DistrictId",
                table: "mscore_addresses",
                newName: "IX_mscore_addresses_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                table: "mscore_addresses",
                newName: "IX_mscore_addresses_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mscore_states",
                table: "mscore_states",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mscore_medias",
                table: "mscore_medias",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mscore_districts",
                table: "mscore_districts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mscore_coumtries",
                table: "mscore_coumtries",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mscore_companies",
                table: "mscore_companies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mscore_cities",
                table: "mscore_cities",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mscore_addresses",
                table: "mscore_addresses",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_addresses_mscore_cities_CityId",
                table: "mscore_addresses",
                column: "CityId",
                principalTable: "mscore_cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_addresses_mscore_districts_DistrictId",
                table: "mscore_addresses",
                column: "DistrictId",
                principalTable: "mscore_districts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_cities_mscore_addresses_AddressId",
                table: "mscore_cities",
                column: "AddressId",
                principalTable: "mscore_addresses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_cities_mscore_districts_DistrictId",
                table: "mscore_cities",
                column: "DistrictId",
                principalTable: "mscore_districts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_cities_mscore_states_StateId",
                table: "mscore_cities",
                column: "StateId",
                principalTable: "mscore_states",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_coumtries_mscore_states_StateId",
                table: "mscore_coumtries",
                column: "StateId",
                principalTable: "mscore_states",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_coumtries_mscore_states_StateId1",
                table: "mscore_coumtries",
                column: "StateId1",
                principalTable: "mscore_states",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_districts_mscore_addresses_AddressId",
                table: "mscore_districts",
                column: "AddressId",
                principalTable: "mscore_addresses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_districts_mscore_cities_CityId",
                table: "mscore_districts",
                column: "CityId",
                principalTable: "mscore_cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_states_mscore_cities_CityId",
                table: "mscore_states",
                column: "CityId",
                principalTable: "mscore_cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_mscore_states_mscore_coumtries_CountryId",
                table: "mscore_states",
                column: "CountryId",
                principalTable: "mscore_coumtries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscore_addresses_mscore_cities_CityId",
                table: "mscore_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_addresses_mscore_districts_DistrictId",
                table: "mscore_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_cities_mscore_addresses_AddressId",
                table: "mscore_cities");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_cities_mscore_districts_DistrictId",
                table: "mscore_cities");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_cities_mscore_states_StateId",
                table: "mscore_cities");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_coumtries_mscore_states_StateId",
                table: "mscore_coumtries");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_coumtries_mscore_states_StateId1",
                table: "mscore_coumtries");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_districts_mscore_addresses_AddressId",
                table: "mscore_districts");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_districts_mscore_cities_CityId",
                table: "mscore_districts");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_states_mscore_cities_CityId",
                table: "mscore_states");

            migrationBuilder.DropForeignKey(
                name: "FK_mscore_states_mscore_coumtries_CountryId",
                table: "mscore_states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mscore_states",
                table: "mscore_states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mscore_medias",
                table: "mscore_medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mscore_districts",
                table: "mscore_districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mscore_coumtries",
                table: "mscore_coumtries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mscore_companies",
                table: "mscore_companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mscore_cities",
                table: "mscore_cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mscore_addresses",
                table: "mscore_addresses");

            migrationBuilder.RenameTable(
                name: "mscore_states",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "mscore_medias",
                newName: "Medias");

            migrationBuilder.RenameTable(
                name: "mscore_districts",
                newName: "Districts");

            migrationBuilder.RenameTable(
                name: "mscore_coumtries",
                newName: "Coumtries");

            migrationBuilder.RenameTable(
                name: "mscore_companies",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "mscore_cities",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "mscore_addresses",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_states_CountryId",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_states_CityId",
                table: "States",
                newName: "IX_States_CityId");

            migrationBuilder.RenameColumn(
                name: "caption",
                table: "Medias",
                newName: "Caption");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Medias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "media_type",
                table: "Medias",
                newName: "MediaType");

            migrationBuilder.RenameColumn(
                name: "file_size",
                table: "Medias",
                newName: "FileSize");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "Medias",
                newName: "FileName");

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

            migrationBuilder.RenameIndex(
                name: "IX_mscore_districts_CityId",
                table: "Districts",
                newName: "IX_Districts_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_districts_AddressId",
                table: "Districts",
                newName: "IX_Districts_AddressId");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Coumtries",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Coumtries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_zip_code_enabled",
                table: "Coumtries",
                newName: "IsZipCodeEnabled");

            migrationBuilder.RenameColumn(
                name: "is_shipping_enabled",
                table: "Coumtries",
                newName: "IsShippingEnabled");

            migrationBuilder.RenameColumn(
                name: "is_dDistrict_enabled",
                table: "Coumtries",
                newName: "IsDistrictEnabled");

            migrationBuilder.RenameColumn(
                name: "is_city_enabled",
                table: "Coumtries",
                newName: "IsCityEnabled");

            migrationBuilder.RenameColumn(
                name: "is_billing_enabled",
                table: "Coumtries",
                newName: "IsBillingEnabled");

            migrationBuilder.RenameColumn(
                name: "country_name",
                table: "Coumtries",
                newName: "CountryName");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_coumtries_StateId1",
                table: "Coumtries",
                newName: "IX_Coumtries_StateId1");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_coumtries_StateId",
                table: "Coumtries",
                newName: "IX_Coumtries_StateId");

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
                table: "Cities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "city_name",
                table: "Cities",
                newName: "CityName");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_cities_StateId",
                table: "Cities",
                newName: "IX_Cities_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_cities_DistrictId",
                table: "Cities",
                newName: "IX_Cities_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_cities_AddressId",
                table: "Cities",
                newName: "IX_Cities_AddressId");

            migrationBuilder.RenameColumn(
                name: "contactName",
                table: "Addresses",
                newName: "ContactName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Addresses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "address_line",
                table: "Addresses",
                newName: "AddressLine");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_addresses_DistrictId",
                table: "Addresses",
                newName: "IX_Addresses_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_mscore_addresses_CityId",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coumtries",
                table: "Coumtries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Addresses_AddressId",
                table: "Cities",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Districts_DistrictId",
                table: "Cities",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Addresses_AddressId",
                table: "Districts",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Cities_CityId",
                table: "States",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Coumtries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Coumtries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
