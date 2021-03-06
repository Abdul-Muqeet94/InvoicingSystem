﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SimpleInvoices;

namespace invoicingSystem.Migrations
{
    [DbContext(typeof(InvoiceContext))]
    partial class InvoiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleInvoices.Billers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("city");

                    b.Property<string>("contact");

                    b.Property<string>("email");

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("billers");
                });

            modelBuilder.Entity("SimpleInvoices.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("city");

                    b.Property<string>("contact");

                    b.Property<string>("email");

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("SimpleInvoices.CustomersBillersProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomersId");

                    b.Property<int?>("billersId");

                    b.Property<bool>("enable");

                    b.Property<int?>("productId");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.HasIndex("billersId");

                    b.HasIndex("productId");

                    b.ToTable("customersBillersProducts");
                });

            modelBuilder.Entity("SimpleInvoices.CustomFields", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("enable");

                    b.Property<string>("fieldName");

                    b.Property<string>("fieldValue");

                    b.Property<string>("tableName");

                    b.HasKey("Id");

                    b.ToTable("customFields");
                });

            modelBuilder.Entity("SimpleInvoices.Design", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("color");

                    b.Property<string>("cut");

                    b.Property<bool>("enable");

                    b.Property<string>("fabric");

                    b.Property<string>("note");

                    b.HasKey("Id");

                    b.ToTable("design");
                });

            modelBuilder.Entity("SimpleInvoices.LedgerDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("amount");

                    b.Property<bool>("enable");

                    b.Property<int?>("paymentTypesId");

                    b.HasKey("Id");

                    b.HasIndex("paymentTypesId");

                    b.ToTable("ledgerDetails");
                });

            modelBuilder.Entity("SimpleInvoices.Ledgers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LedgerDetailsId");

                    b.Property<double>("amount");

                    b.Property<double>("balance");

                    b.Property<int?>("customersBillersProductsId");

                    b.Property<DateTime>("dueDate");

                    b.Property<bool>("enable");

                    b.HasKey("Id");

                    b.HasIndex("LedgerDetailsId");

                    b.HasIndex("customersBillersProductsId");

                    b.ToTable("ledgers");
                });

            modelBuilder.Entity("SimpleInvoices.PaymentTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("paymentTypes");
                });

            modelBuilder.Entity("SimpleInvoices.ProcuctDesign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DesignId");

                    b.Property<bool>("enable");

                    b.Property<int?>("productId");

                    b.HasKey("Id");

                    b.HasIndex("DesignId");

                    b.HasIndex("productId");

                    b.ToTable("productDesign");
                });

            modelBuilder.Entity("SimpleInvoices.product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("color");

                    b.Property<DateTime>("createdOn");

                    b.Property<string>("description");

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.Property<string>("note");

                    b.Property<double>("price");

                    b.Property<double>("unitPrice");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("SimpleInvoices.ProductTaxes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TaxesId");

                    b.Property<bool>("enable");

                    b.Property<int?>("productId");

                    b.HasKey("Id");

                    b.HasIndex("TaxesId");

                    b.HasIndex("productId");

                    b.ToTable("ProductTaxes");
                });

            modelBuilder.Entity("SimpleInvoices.Taxes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.Property<string>("value");

                    b.HasKey("Id");

                    b.ToTable("taxes");
                });

            modelBuilder.Entity("SimpleInvoices.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.Property<string>("password");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("SimpleInvoices.CustomersBillersProducts", b =>
                {
                    b.HasOne("SimpleInvoices.Customers")
                        .WithMany("customersBillersProducts")
                        .HasForeignKey("CustomersId");

                    b.HasOne("SimpleInvoices.Billers", "billers")
                        .WithMany()
                        .HasForeignKey("billersId");

                    b.HasOne("SimpleInvoices.product")
                        .WithMany("customersBillersProduct")
                        .HasForeignKey("productId");
                });

            modelBuilder.Entity("SimpleInvoices.LedgerDetails", b =>
                {
                    b.HasOne("SimpleInvoices.PaymentTypes", "paymentTypes")
                        .WithMany()
                        .HasForeignKey("paymentTypesId");
                });

            modelBuilder.Entity("SimpleInvoices.Ledgers", b =>
                {
                    b.HasOne("SimpleInvoices.LedgerDetails")
                        .WithMany("ledgers")
                        .HasForeignKey("LedgerDetailsId");

                    b.HasOne("SimpleInvoices.CustomersBillersProducts", "customersBillersProducts")
                        .WithMany()
                        .HasForeignKey("customersBillersProductsId");
                });

            modelBuilder.Entity("SimpleInvoices.ProcuctDesign", b =>
                {
                    b.HasOne("SimpleInvoices.Design")
                        .WithMany("productDesign")
                        .HasForeignKey("DesignId");

                    b.HasOne("SimpleInvoices.product")
                        .WithMany("productDesign")
                        .HasForeignKey("productId");
                });

            modelBuilder.Entity("SimpleInvoices.ProductTaxes", b =>
                {
                    b.HasOne("SimpleInvoices.Taxes")
                        .WithMany("productTaxes")
                        .HasForeignKey("TaxesId");

                    b.HasOne("SimpleInvoices.product")
                        .WithMany("productTaxes")
                        .HasForeignKey("productId");
                });
        }
    }
}
