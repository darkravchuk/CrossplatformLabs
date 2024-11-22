﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.SqlServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241122192611_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Council_Tax", b =>
                {
                    b.Property<int>("CtResidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CtResidentId"));

                    b.Property<string>("CtAddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CtAddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CtAddressLine3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CtCityTown")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CtOtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CtPostcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CtResidentId");

                    b.ToTable("CouncilTaxes");

                    b.HasData(
                        new
                        {
                            CtResidentId = 1,
                            CtAddressLine1 = "123 Main St",
                            CtAddressLine2 = "",
                            CtAddressLine3 = "",
                            CtCityTown = "New York",
                            CtOtherDetails = "Council tax for 2023",
                            CtPostcode = "10001"
                        });
                });

            modelBuilder.Entity("Models.Customer_System", b =>
                {
                    b.Property<string>("SystemCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SystemCode");

                    b.ToTable("CustomerSystems");

                    b.HasData(
                        new
                        {
                            SystemCode = "CT",
                            SystemName = "Council Tax"
                        },
                        new
                        {
                            SystemCode = "ER",
                            SystemName = "Electoral Register"
                        });
                });

            modelBuilder.Entity("Models.Electoral_Register", b =>
                {
                    b.Property<int>("ErVoterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ErVoterId"));

                    b.Property<string>("ErAddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErAddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErCityTown")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErOtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErPostcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ErVoterId");

                    b.ToTable("ElectoralRegisters");

                    b.HasData(
                        new
                        {
                            ErVoterId = 1,
                            ErAddressLine1 = "789 Oak St",
                            ErAddressLine2 = "Apt 4",
                            ErCityTown = "Los Angeles",
                            ErOtherDetails = "Registered voter for 2024",
                            ErPostcode = "90001"
                        });
                });

            modelBuilder.Entity("Models.Housing_Benefit", b =>
                {
                    b.Property<int>("HbRecipientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HbRecipientId"));

                    b.Property<string>("HbAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HbOtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HbPostcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HbRecipientId");

                    b.ToTable("HousingBenefits");

                    b.HasData(
                        new
                        {
                            HbRecipientId = 1,
                            HbAddress = "456 Elm St",
                            HbOtherDetails = "Low-income assistance",
                            HbPostcode = "10002"
                        });
                });

            modelBuilder.Entity("Models.ISO_Country_Code", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryCode");

                    b.ToTable("IsoCountryCodes");

                    b.HasData(
                        new
                        {
                            CountryCode = "US",
                            CountryName = "United States"
                        },
                        new
                        {
                            CountryCode = "UA",
                            CountryName = "Ukraine"
                        });
                });

            modelBuilder.Entity("Models.MDM_Customer", b =>
                {
                    b.Property<int>("MdmCustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MdmCustomerId"));

                    b.Property<DateTime>("MdmDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatAddressId")
                        .HasColumnType("int");

                    b.HasKey("MdmCustomerId");

                    b.HasIndex("PatAddressId");

                    b.ToTable("MdmCustomers");

                    b.HasData(
                        new
                        {
                            MdmCustomerId = 1,
                            MdmDateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OtherDetails = "Regular customer",
                            PatAddressId = 1
                        });
                });

            modelBuilder.Entity("Models.MDM_Customer_Index", b =>
                {
                    b.Property<int>("MdmCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("SystemCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SystemCustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MdmCustomerId", "SystemCode");

                    b.HasIndex("SystemCode");

                    b.ToTable("MdmCustomerIndexes");

                    b.HasData(
                        new
                        {
                            MdmCustomerId = 1,
                            SystemCode = "CT",
                            SystemCustomerId = "CT001"
                        });
                });

            modelBuilder.Entity("Models.MDM_Customer_Service", b =>
                {
                    b.Property<int>("CustomersServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomersServiceId"));

                    b.Property<decimal>("CostOfService")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateServiceReceived")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateServiceRequested")
                        .HasColumnType("datetime2");

                    b.Property<int>("MdmCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("CustomersServiceId");

                    b.HasIndex("MdmCustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("MdmCustomerServices");

                    b.HasData(
                        new
                        {
                            CustomersServiceId = 1,
                            CostOfService = 100.00m,
                            DateServiceReceived = new DateTime(2024, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            DateServiceRequested = new DateTime(2024, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            MdmCustomerId = 1,
                            OtherDetails = "Paid online",
                            ServiceId = 1
                        });
                });

            modelBuilder.Entity("Models.MDM_Payment", b =>
                {
                    b.Property<int>("MdmPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MdmPaymentId"));

                    b.Property<decimal>("AmountOfPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomersServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethodCode")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatusCode")
                        .HasColumnType("int");

                    b.HasKey("MdmPaymentId");

                    b.HasIndex("CustomersServiceId");

                    b.ToTable("MdmPayments");

                    b.HasData(
                        new
                        {
                            MdmPaymentId = 1,
                            AmountOfPayment = 100.00m,
                            CustomersServiceId = 1,
                            DateOfPayment = new DateTime(2024, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            OtherDetails = "Transaction successful",
                            PaymentMethodCode = 101,
                            PaymentStatusCode = 1
                        });
                });

            modelBuilder.Entity("Models.MDM_Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceCategoryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ServiceCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("MdmServices");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            OtherDetails = "Online service",
                            ServiceCategoryCode = "FINE",
                            ServiceCost = 100.00m,
                            ServiceDescription = "Parking fine payment",
                            ServiceName = "Pay Fine"
                        });
                });

            modelBuilder.Entity("Models.Parking_Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("AmountOfPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethodCode")
                        .HasColumnType("int");

                    b.Property<int>("PtOffenderId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("PtOffenderId");

                    b.ToTable("ParkingPayments");

                    b.HasData(
                        new
                        {
                            PaymentId = 1,
                            AmountOfPayment = 50.00m,
                            DateOfPayment = new DateTime(2024, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            OtherDetails = "Paid with credit card",
                            PaymentMethodCode = 101,
                            PtOffenderId = 1
                        });
                });

            modelBuilder.Entity("Models.Parking_Ticket", b =>
                {
                    b.Property<int>("PtOffenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PtOffenderId"));

                    b.Property<string>("PtAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PtOtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PtOffenderId");

                    b.ToTable("ParkingTickets");

                    b.HasData(
                        new
                        {
                            PtOffenderId = 1,
                            PtAddress = "Parking Lot A",
                            PtOtherDetails = "Overtime parking violation"
                        });
                });

            modelBuilder.Entity("Models.Social_Service", b =>
                {
                    b.Property<int>("SsClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SsClientId"));

                    b.Property<string>("SsOtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SsClientId");

                    b.ToTable("SocialServices");

                    b.HasData(
                        new
                        {
                            SsClientId = 1,
                            SsOtherDetails = "Healthcare support"
                        });
                });

            modelBuilder.Entity("Models.UK_PAF_File", b =>
                {
                    b.Property<int>("PatAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatAddressId"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityTown")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatAddressId");

                    b.HasIndex("CountryCode");

                    b.ToTable("UkPafFiles");

                    b.HasData(
                        new
                        {
                            PatAddressId = 1,
                            AddressLine1 = "123 Main St",
                            AddressLine2 = "Suite 200",
                            AddressLine3 = "",
                            CityTown = "New York",
                            Country = "United States",
                            CountryCode = "US",
                            Postcode = "10001"
                        });
                });

            modelBuilder.Entity("Models.MDM_Customer", b =>
                {
                    b.HasOne("Models.UK_PAF_File", "PatAddress")
                        .WithMany("MdmCustomers")
                        .HasForeignKey("PatAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatAddress");
                });

            modelBuilder.Entity("Models.MDM_Customer_Index", b =>
                {
                    b.HasOne("Models.MDM_Customer", "MdmCustomer")
                        .WithMany("MdmCustomerIndexes")
                        .HasForeignKey("MdmCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Customer_System", "System")
                        .WithMany("MdmCustomerIndexes")
                        .HasForeignKey("SystemCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MdmCustomer");

                    b.Navigation("System");
                });

            modelBuilder.Entity("Models.MDM_Customer_Service", b =>
                {
                    b.HasOne("Models.MDM_Customer", "MdmCustomer")
                        .WithMany("MdmCustomerServices")
                        .HasForeignKey("MdmCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.MDM_Service", "Service")
                        .WithMany("MdmCustomerServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MdmCustomer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Models.MDM_Payment", b =>
                {
                    b.HasOne("Models.MDM_Customer_Service", "CustomersService")
                        .WithMany("MdmPayments")
                        .HasForeignKey("CustomersServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomersService");
                });

            modelBuilder.Entity("Models.Parking_Payment", b =>
                {
                    b.HasOne("Models.Parking_Ticket", "PtOffender")
                        .WithMany("ParkingPayments")
                        .HasForeignKey("PtOffenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PtOffender");
                });

            modelBuilder.Entity("Models.UK_PAF_File", b =>
                {
                    b.HasOne("Models.ISO_Country_Code", "CountryCodeNavigation")
                        .WithMany("UKPafFiles")
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryCodeNavigation");
                });

            modelBuilder.Entity("Models.Customer_System", b =>
                {
                    b.Navigation("MdmCustomerIndexes");
                });

            modelBuilder.Entity("Models.ISO_Country_Code", b =>
                {
                    b.Navigation("UKPafFiles");
                });

            modelBuilder.Entity("Models.MDM_Customer", b =>
                {
                    b.Navigation("MdmCustomerIndexes");

                    b.Navigation("MdmCustomerServices");
                });

            modelBuilder.Entity("Models.MDM_Customer_Service", b =>
                {
                    b.Navigation("MdmPayments");
                });

            modelBuilder.Entity("Models.MDM_Service", b =>
                {
                    b.Navigation("MdmCustomerServices");
                });

            modelBuilder.Entity("Models.Parking_Ticket", b =>
                {
                    b.Navigation("ParkingPayments");
                });

            modelBuilder.Entity("Models.UK_PAF_File", b =>
                {
                    b.Navigation("MdmCustomers");
                });
#pragma warning restore 612, 618
        }
    }
}
