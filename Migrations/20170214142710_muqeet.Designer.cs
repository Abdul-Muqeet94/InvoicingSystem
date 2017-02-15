using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SimpleInvoices;

namespace invoicingSystem.Migrations
{
    [DbContext(typeof(InvoiceContext))]
    [Migration("20170214142710_muqeet")]
    partial class muqeet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleInvoices.CustomersBillers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("city");

                    b.Property<string>("contact");

                    b.Property<string>("email");

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.Property<int?>("userTypeId");

                    b.HasKey("Id");

                    b.HasIndex("userTypeId");

                    b.ToTable("customersBillers");
                });

            modelBuilder.Entity("SimpleInvoices.CustomersBillersProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("billersId");

                    b.Property<int?>("customersId");

                    b.Property<bool>("enable");

                    b.Property<int?>("productId");

                    b.HasKey("Id");

                    b.HasIndex("billersId");

                    b.HasIndex("customersId");

                    b.HasIndex("productId");

                    b.ToTable("customersBillersProducts");
                });

            modelBuilder.Entity("SimpleInvoices.CustomFields", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("enable");

                    b.Property<string>("fieldName");

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

            modelBuilder.Entity("SimpleInvoices.FieldValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomFieldsId");

                    b.Property<int>("IdUser");

                    b.Property<int?>("customBillersId");

                    b.Property<bool>("enable");

                    b.Property<string>("value");

                    b.HasKey("Id");

                    b.HasIndex("CustomFieldsId");

                    b.HasIndex("customBillersId");

                    b.ToTable("FieldValues");
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

            modelBuilder.Entity("SimpleInvoices.UsersType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("userType");
                });

            modelBuilder.Entity("SimpleInvoices.CustomersBillers", b =>
                {
                    b.HasOne("SimpleInvoices.UsersType", "userType")
                        .WithMany()
                        .HasForeignKey("userTypeId");
                });

            modelBuilder.Entity("SimpleInvoices.CustomersBillersProducts", b =>
                {
                    b.HasOne("SimpleInvoices.CustomersBillers", "billers")
                        .WithMany()
                        .HasForeignKey("billersId");

                    b.HasOne("SimpleInvoices.CustomersBillers", "customers")
                        .WithMany()
                        .HasForeignKey("customersId");

                    b.HasOne("SimpleInvoices.product", "product")
                        .WithMany()
                        .HasForeignKey("productId");
                });

            modelBuilder.Entity("SimpleInvoices.FieldValue", b =>
                {
                    b.HasOne("SimpleInvoices.CustomFields")
                        .WithMany("FieldValues")
                        .HasForeignKey("CustomFieldsId");

                    b.HasOne("SimpleInvoices.CustomersBillers", "customBillers")
                        .WithMany()
                        .HasForeignKey("customBillersId");
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
