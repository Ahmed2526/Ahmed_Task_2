using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ahmed_Task_2.Web.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceParties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RegionCity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceParties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateIssued = table.Column<DateOnly>(type: "date", nullable: false),
                    ActivityCodeId = table.Column<int>(type: "int", nullable: false),
                    IssuerId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_ActivityCodes_ActivityCodeId",
                        column: x => x.ActivityCodeId,
                        principalTable: "ActivityCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceParties_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "InvoiceParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceParties_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "InvoiceParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxSubTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaxTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxSubTypes_TaxTypes_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalTable: "TaxTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    SalesTotal = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    DiscountPerUnit = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    TotalTaxableFees = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    NetTotal = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceLineId = table.Column<int>(type: "int", nullable: false),
                    TaxTypeId = table.Column<int>(type: "int", nullable: false),
                    TaxSubTypeId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceTaxes_InvoiceLines_InvoiceLineId",
                        column: x => x.InvoiceLineId,
                        principalTable: "InvoiceLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceTaxes_TaxSubTypes_TaxSubTypeId",
                        column: x => x.TaxSubTypeId,
                        principalTable: "TaxSubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceTaxes_TaxTypes_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalTable: "TaxTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ActivityCodes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 111, "Cultivation of grains and crops (except for rice), legumes and oilseeds" },
                    { 112, "Cultivation of rice" },
                    { 113, "Cultivation of vegetables, melons, roots and tubers" },
                    { 114, "Cultivation of sugar cane" },
                    { 115, "Tobacco cultivation" },
                    { 116, "Growing fibre crops" },
                    { 119, "Cultivation of other non-perennial crops" },
                    { 121, "The cultivation of grapefruit" },
                    { 122, "Growing tropical and subtropical fruits" },
                    { 123, "Cultivation of citrus fruits" },
                    { 124, "Cultivation of fruit with stone kernel and from palm trees" },
                    { 125, "Plant fruit trees and shrubs and other nuts" },
                    { 127, "Growing of tea" },
                    { 128, "Cultivation of spices crops, aromatic, medicinal and pharmaceutical drugs" },
                    { 129, "Cultivation of other perennial crops" },
                    { 130, "Propagation" },
                    { 141, "Breeding of cattle and buffalo" },
                    { 142, "Breeding of horses and mare" },
                    { 143, "Breeding of camels" },
                    { 144, "Breeding sheep and goat" },
                    { 145, "Breeding of pig" },
                    { 146, "Poultry farming" },
                    { 149, "Breeding other animals" },
                    { 150, "Mixed agricultural and animal production" },
                    { 161, "Support activities for animal production" },
                    { 162, "Activities in support of animal production" },
                    { 163, "Post-harvest activities" },
                    { 164, "Preparing grains for production" }
                });

            migrationBuilder.InsertData(
                table: "TaxTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "T1 - Value added tax" },
                    { 2, "T2 - Table tax (percentage)" },
                    { 3, "T3 - Table tax (fixed amount)" },
                    { 4, "T4 - Withholding tax (WHT)" },
                    { 5, "T5 - Stamping tax (percentage)" },
                    { 6, "T6 - Stamping tax (amount)" },
                    { 7, "T7 - Entertainment tax" },
                    { 8, "T8 - Resource development fee" },
                    { 9, "T9 - Table tax (percentage)" },
                    { 10, "T10 - Municipality fees" },
                    { 11, "T11 - Medical insurance fee" },
                    { 12, "T12 - Other fees" }
                });

            migrationBuilder.InsertData(
                table: "TaxSubTypes",
                columns: new[] { "Id", "Name", "TaxTypeId" },
                values: new object[,]
                {
                    { 1, "V001 - Standard VAT Rate", 1 },
                    { 2, "V002 - Zero Rated VAT", 1 },
                    { 3, "V003 - Exempt VAT", 1 },
                    { 4, "TP001 - Local Services", 2 },
                    { 5, "TP002 - Luxury Goods", 2 },
                    { 6, "TF001 - Fixed Service Fee", 3 },
                    { 7, "TF002 - Fixed Product Fee", 3 },
                    { 8, "W001 - Contractors", 4 },
                    { 9, "W002 - Professional Services", 4 },
                    { 10, "W003 - Suppliers", 4 },
                    { 11, "SP001 - Commercial Contracts", 5 },
                    { 12, "SF001 - Fixed Stamp Duty", 6 },
                    { 13, "E001 - Cinema", 7 },
                    { 14, "E002 - Events", 7 },
                    { 15, "R001 - Tourism", 8 },
                    { 16, "R002 - Government Services", 8 },
                    { 17, "TP003 - Imported Goods", 9 },
                    { 18, "M001 - Municipality Services", 10 },
                    { 19, "MI001 - Medical Insurance Contribution", 11 },
                    { 20, "O001 - Administrative Fee", 12 },
                    { 21, "O002 - Processing Fee", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceId",
                table: "InvoiceLines",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceParties_RegistrationId",
                table: "InvoiceParties",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ActivityCodeId",
                table: "Invoices",
                column: "ActivityCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InternalId",
                table: "Invoices",
                column: "InternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_IssuerId",
                table: "Invoices",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ReceiverId",
                table: "Invoices",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTaxes_InvoiceLineId",
                table: "InvoiceTaxes",
                column: "InvoiceLineId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTaxes_TaxSubTypeId",
                table: "InvoiceTaxes",
                column: "TaxSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTaxes_TaxTypeId",
                table: "InvoiceTaxes",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxSubTypes_TaxTypeId",
                table: "TaxSubTypes",
                column: "TaxTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceTaxes");

            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "TaxSubTypes");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "TaxTypes");

            migrationBuilder.DropTable(
                name: "ActivityCodes");

            migrationBuilder.DropTable(
                name: "InvoiceParties");
        }
    }
}
