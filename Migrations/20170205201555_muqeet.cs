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
                name: "billers",
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
                    table.PrimaryKey("PK_billers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
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
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    enable = table.Column<bool>(nullable: false),
                    fieldName = table.Column<string>(nullable: true),
                    fieldValue = table.Column<string>(nullable: true),
                    tableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customFields", x => x.Id);
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
                    value = table.Column<string>(nullable: true)
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
                    CustomersId = table.Column<int>(nullable: true),
                    billersId = table.Column<int>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    productId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customersBillersProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customersBillersProducts_customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customersBillersProducts_billers_billersId",
                        column: x => x.billersId,
                        principalTable: "billers",
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
                name: "productDesign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignId = table.Column<int>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    productId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDesign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productDesign_design_DesignId",
                        column: x => x.DesignId,
                        principalTable: "design",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productDesign_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaxesId = table.Column<int>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    productId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTaxes_taxes_TaxesId",
                        column: x => x.TaxesId,
                        principalTable: "taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTaxes_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    customersBillersProductsId = table.Column<int>(nullable: true),
                    dueDate = table.Column<DateTime>(nullable: false),
                    enable = table.Column<bool>(nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_customersBillersProducts_CustomersId",
                table: "customersBillersProducts",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_customersBillersProducts_billersId",
                table: "customersBillersProducts",
                column: "billersId");

            migrationBuilder.CreateIndex(
                name: "IX_customersBillersProducts_productId",
                table: "customersBillersProducts",
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
                name: "IX_productDesign_DesignId",
                table: "productDesign",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_productDesign_productId",
                table: "productDesign",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTaxes_TaxesId",
                table: "ProductTaxes",
                column: "TaxesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTaxes_productId",
                table: "ProductTaxes",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customFields");

            migrationBuilder.DropTable(
                name: "ledgers");

            migrationBuilder.DropTable(
                name: "productDesign");

            migrationBuilder.DropTable(
                name: "ProductTaxes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "ledgerDetails");

            migrationBuilder.DropTable(
                name: "customersBillersProducts");

            migrationBuilder.DropTable(
                name: "design");

            migrationBuilder.DropTable(
                name: "taxes");

            migrationBuilder.DropTable(
                name: "paymentTypes");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "billers");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
