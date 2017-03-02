using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace invoicingSystem.Migrations
{
    public partial class muqeet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "biller",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: true),
                    ankle = table.Column<string>(nullable: true),
                    armHole = table.Column<string>(nullable: true),
                    backNeckDepth = table.Column<string>(nullable: true),
                    backNeckWidth = table.Column<string>(nullable: true),
                    bicep = table.Column<string>(nullable: true),
                    calf = table.Column<string>(nullable: true),
                    chaak = table.Column<string>(nullable: true),
                    chest = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    daaman = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    forearm = table.Column<string>(nullable: true),
                    frontNeckDepth = table.Column<string>(nullable: true),
                    frontNeckWidth = table.Column<string>(nullable: true),
                    fullSleveLength = table.Column<string>(nullable: true),
                    hips = table.Column<string>(nullable: true),
                    imagepath = table.Column<string>(nullable: true),
                    kneeCap = table.Column<string>(nullable: true),
                    longShirtLength = table.Column<string>(nullable: true),
                    lowerWaist = table.Column<string>(nullable: true),
                    measurementType = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    pantLength = table.Column<string>(nullable: true),
                    sholder = table.Column<string>(nullable: true),
                    shortShirtLength = table.Column<string>(nullable: true),
                    sleeveLength = table.Column<string>(nullable: true),
                    thigh = table.Column<string>(nullable: true),
                    upperWaist = table.Column<string>(nullable: true),
                    waist = table.Column<string>(nullable: true),
                    wrist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "design",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    color = table.Column<string>(nullable: true),
                    cut = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    fabric = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_design", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    color = table.Column<string>(nullable: true),
                    createdOn = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    unitPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    percent = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ledgerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    amount = table.Column<double>(nullable: false),
                    enable = table.Column<bool>(nullable: false),
                    paymentTypesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ledgerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ledgerDetails_paymentTypes_paymentTypesId",
                        column: x => x.paymentTypesId,
                        principalTable: "paymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customersBillersProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billersId = table.Column<int>(nullable: true),
                    customersId = table.Column<int>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    productId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customersBillersProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customersBillersProducts_biller_billersId",
                        column: x => x.billersId,
                        principalTable: "biller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customersBillersProducts_customer_customersId",
                        column: x => x.customersId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customersBillersProducts_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    enable = table.Column<bool>(nullable: false),
                    fieldName = table.Column<string>(nullable: true),
                    productId = table.Column<int>(nullable: true),
                    tableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customFields_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productDesign",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false),
                    designId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDesign", x => new { x.productId, x.designId });
                    table.ForeignKey(
                        name: "FK_productDesign_design_designId",
                        column: x => x.designId,
                        principalTable: "design",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productDesign_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ledgers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LedgerDetailsId = table.Column<int>(nullable: true),
                    amount = table.Column<double>(nullable: false),
                    balance = table.Column<double>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    customersBillersProductsId = table.Column<int>(nullable: true),
                    deliveryDate = table.Column<DateTime>(nullable: false),
                    dueDate = table.Column<DateTime>(nullable: false),
                    enable = table.Column<bool>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    taxId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ledgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ledgers_ledgerDetails_LedgerDetailsId",
                        column: x => x.LedgerDetailsId,
                        principalTable: "ledgerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ledgers_customersBillersProducts_customersBillersProductsId",
                        column: x => x.customersBillersProductsId,
                        principalTable: "customersBillersProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ledgers_taxes_taxId",
                        column: x => x.taxId,
                        principalTable: "taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomFieldsId = table.Column<int>(nullable: true),
                    billersId = table.Column<int>(nullable: true),
                    customerId = table.Column<int>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    productId = table.Column<int>(nullable: true),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldValues_customFields_CustomFieldsId",
                        column: x => x.CustomFieldsId,
                        principalTable: "customFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldValues_biller_billersId",
                        column: x => x.billersId,
                        principalTable: "biller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldValues_customer_customerId",
                        column: x => x.customerId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldValues_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customersBillersProducts_billersId",
                table: "customersBillersProducts",
                column: "billersId");

            migrationBuilder.CreateIndex(
                name: "IX_customersBillersProducts_customersId",
                table: "customersBillersProducts",
                column: "customersId");

            migrationBuilder.CreateIndex(
                name: "IX_customersBillersProducts_productId",
                table: "customersBillersProducts",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_customFields_productId",
                table: "customFields",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_CustomFieldsId",
                table: "FieldValues",
                column: "CustomFieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_billersId",
                table: "FieldValues",
                column: "billersId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_customerId",
                table: "FieldValues",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_productId",
                table: "FieldValues",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ledgerDetails_paymentTypesId",
                table: "ledgerDetails",
                column: "paymentTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_ledgers_LedgerDetailsId",
                table: "ledgers",
                column: "LedgerDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ledgers_customersBillersProductsId",
                table: "ledgers",
                column: "customersBillersProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ledgers_taxId",
                table: "ledgers",
                column: "taxId");

            migrationBuilder.CreateIndex(
                name: "IX_productDesign_designId",
                table: "productDesign",
                column: "designId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldValues");

            migrationBuilder.DropTable(
                name: "ledgers");

            migrationBuilder.DropTable(
                name: "productDesign");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "customFields");

            migrationBuilder.DropTable(
                name: "ledgerDetails");

            migrationBuilder.DropTable(
                name: "customersBillersProducts");

            migrationBuilder.DropTable(
                name: "taxes");

            migrationBuilder.DropTable(
                name: "design");

            migrationBuilder.DropTable(
                name: "paymentTypes");

            migrationBuilder.DropTable(
                name: "biller");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
