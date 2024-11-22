using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CouncilTaxes",
                columns: table => new
                {
                    CtResidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CtAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CtAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CtAddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CtCityTown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CtPostcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CtOtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouncilTaxes", x => x.CtResidentId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSystems",
                columns: table => new
                {
                    SystemCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSystems", x => x.SystemCode);
                });

            migrationBuilder.CreateTable(
                name: "ElectoralRegisters",
                columns: table => new
                {
                    ErVoterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErCityTown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErPostcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErOtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectoralRegisters", x => x.ErVoterId);
                });

            migrationBuilder.CreateTable(
                name: "HousingBenefits",
                columns: table => new
                {
                    HbRecipientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HbAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HbPostcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HbOtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingBenefits", x => x.HbRecipientId);
                });

            migrationBuilder.CreateTable(
                name: "IsoCountryCodes",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsoCountryCodes", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "MdmServices",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MdmServices", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingTickets",
                columns: table => new
                {
                    PtOffenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PtAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PtOtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTickets", x => x.PtOffenderId);
                });

            migrationBuilder.CreateTable(
                name: "SocialServices",
                columns: table => new
                {
                    SsClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SsOtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialServices", x => x.SsClientId);
                });

            migrationBuilder.CreateTable(
                name: "UkPafFiles",
                columns: table => new
                {
                    PatAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityTown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UkPafFiles", x => x.PatAddressId);
                    table.ForeignKey(
                        name: "FK_UkPafFiles_IsoCountryCodes_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "IsoCountryCodes",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingPayments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PtOffenderId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodCode = table.Column<int>(type: "int", nullable: false),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPayments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_ParkingPayments_ParkingTickets_PtOffenderId",
                        column: x => x.PtOffenderId,
                        principalTable: "ParkingTickets",
                        principalColumn: "PtOffenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MdmCustomers",
                columns: table => new
                {
                    MdmCustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatAddressId = table.Column<int>(type: "int", nullable: false),
                    MdmDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MdmCustomers", x => x.MdmCustomerId);
                    table.ForeignKey(
                        name: "FK_MdmCustomers_UkPafFiles_PatAddressId",
                        column: x => x.PatAddressId,
                        principalTable: "UkPafFiles",
                        principalColumn: "PatAddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MdmCustomerIndexes",
                columns: table => new
                {
                    MdmCustomerId = table.Column<int>(type: "int", nullable: false),
                    SystemCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SystemCustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MdmCustomerIndexes", x => new { x.MdmCustomerId, x.SystemCode });
                    table.ForeignKey(
                        name: "FK_MdmCustomerIndexes_CustomerSystems_SystemCode",
                        column: x => x.SystemCode,
                        principalTable: "CustomerSystems",
                        principalColumn: "SystemCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MdmCustomerIndexes_MdmCustomers_MdmCustomerId",
                        column: x => x.MdmCustomerId,
                        principalTable: "MdmCustomers",
                        principalColumn: "MdmCustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MdmCustomerServices",
                columns: table => new
                {
                    CustomersServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MdmCustomerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    DateServiceRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateServiceReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostOfService = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MdmCustomerServices", x => x.CustomersServiceId);
                    table.ForeignKey(
                        name: "FK_MdmCustomerServices_MdmCustomers_MdmCustomerId",
                        column: x => x.MdmCustomerId,
                        principalTable: "MdmCustomers",
                        principalColumn: "MdmCustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MdmCustomerServices_MdmServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "MdmServices",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MdmPayments",
                columns: table => new
                {
                    MdmPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomersServiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodCode = table.Column<int>(type: "int", nullable: false),
                    PaymentStatusCode = table.Column<int>(type: "int", nullable: false),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MdmPayments", x => x.MdmPaymentId);
                    table.ForeignKey(
                        name: "FK_MdmPayments_MdmCustomerServices_CustomersServiceId",
                        column: x => x.CustomersServiceId,
                        principalTable: "MdmCustomerServices",
                        principalColumn: "CustomersServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CouncilTaxes",
                columns: new[] { "CtResidentId", "CtAddressLine1", "CtAddressLine2", "CtAddressLine3", "CtCityTown", "CtOtherDetails", "CtPostcode" },
                values: new object[] { 1, "123 Main St", "", "", "New York", "Council tax for 2023", "10001" });

            migrationBuilder.InsertData(
                table: "CustomerSystems",
                columns: new[] { "SystemCode", "SystemName" },
                values: new object[,]
                {
                    { "CT", "Council Tax" },
                    { "ER", "Electoral Register" }
                });

            migrationBuilder.InsertData(
                table: "ElectoralRegisters",
                columns: new[] { "ErVoterId", "ErAddressLine1", "ErAddressLine2", "ErCityTown", "ErOtherDetails", "ErPostcode" },
                values: new object[] { 1, "789 Oak St", "Apt 4", "Los Angeles", "Registered voter for 2024", "90001" });

            migrationBuilder.InsertData(
                table: "HousingBenefits",
                columns: new[] { "HbRecipientId", "HbAddress", "HbOtherDetails", "HbPostcode" },
                values: new object[] { 1, "456 Elm St", "Low-income assistance", "10002" });

            migrationBuilder.InsertData(
                table: "IsoCountryCodes",
                columns: new[] { "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "UA", "Ukraine" },
                    { "US", "United States" }
                });

            migrationBuilder.InsertData(
                table: "MdmServices",
                columns: new[] { "ServiceId", "OtherDetails", "ServiceCategoryCode", "ServiceCost", "ServiceDescription", "ServiceName" },
                values: new object[] { 1, "Online service", "FINE", 100.00m, "Parking fine payment", "Pay Fine" });

            migrationBuilder.InsertData(
                table: "ParkingTickets",
                columns: new[] { "PtOffenderId", "PtAddress", "PtOtherDetails" },
                values: new object[] { 1, "Parking Lot A", "Overtime parking violation" });

            migrationBuilder.InsertData(
                table: "SocialServices",
                columns: new[] { "SsClientId", "SsOtherDetails" },
                values: new object[] { 1, "Healthcare support" });

            migrationBuilder.InsertData(
                table: "ParkingPayments",
                columns: new[] { "PaymentId", "AmountOfPayment", "DateOfPayment", "OtherDetails", "PaymentMethodCode", "PtOffenderId" },
                values: new object[] { 1, 50.00m, new DateTime(2024, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Paid with credit card", 101, 1 });

            migrationBuilder.InsertData(
                table: "UkPafFiles",
                columns: new[] { "PatAddressId", "AddressLine1", "AddressLine2", "AddressLine3", "CityTown", "Country", "CountryCode", "Postcode" },
                values: new object[] { 1, "123 Main St", "Suite 200", "", "New York", "United States", "US", "10001" });

            migrationBuilder.InsertData(
                table: "MdmCustomers",
                columns: new[] { "MdmCustomerId", "MdmDateOfBirth", "OtherDetails", "PatAddressId" },
                values: new object[] { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular customer", 1 });

            migrationBuilder.InsertData(
                table: "MdmCustomerIndexes",
                columns: new[] { "MdmCustomerId", "SystemCode", "SystemCustomerId" },
                values: new object[] { 1, "CT", "CT001" });

            migrationBuilder.InsertData(
                table: "MdmCustomerServices",
                columns: new[] { "CustomersServiceId", "CostOfService", "DateServiceReceived", "DateServiceRequested", "MdmCustomerId", "OtherDetails", "ServiceId" },
                values: new object[] { 1, 100.00m, new DateTime(2024, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, "Paid online", 1 });

            migrationBuilder.InsertData(
                table: "MdmPayments",
                columns: new[] { "MdmPaymentId", "AmountOfPayment", "CustomersServiceId", "DateOfPayment", "OtherDetails", "PaymentMethodCode", "PaymentStatusCode" },
                values: new object[] { 1, 100.00m, 1, new DateTime(2024, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Transaction successful", 101, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MdmCustomerIndexes_SystemCode",
                table: "MdmCustomerIndexes",
                column: "SystemCode");

            migrationBuilder.CreateIndex(
                name: "IX_MdmCustomers_PatAddressId",
                table: "MdmCustomers",
                column: "PatAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MdmCustomerServices_MdmCustomerId",
                table: "MdmCustomerServices",
                column: "MdmCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MdmCustomerServices_ServiceId",
                table: "MdmCustomerServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MdmPayments_CustomersServiceId",
                table: "MdmPayments",
                column: "CustomersServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPayments_PtOffenderId",
                table: "ParkingPayments",
                column: "PtOffenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UkPafFiles_CountryCode",
                table: "UkPafFiles",
                column: "CountryCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouncilTaxes");

            migrationBuilder.DropTable(
                name: "ElectoralRegisters");

            migrationBuilder.DropTable(
                name: "HousingBenefits");

            migrationBuilder.DropTable(
                name: "MdmCustomerIndexes");

            migrationBuilder.DropTable(
                name: "MdmPayments");

            migrationBuilder.DropTable(
                name: "ParkingPayments");

            migrationBuilder.DropTable(
                name: "SocialServices");

            migrationBuilder.DropTable(
                name: "CustomerSystems");

            migrationBuilder.DropTable(
                name: "MdmCustomerServices");

            migrationBuilder.DropTable(
                name: "ParkingTickets");

            migrationBuilder.DropTable(
                name: "MdmCustomers");

            migrationBuilder.DropTable(
                name: "MdmServices");

            migrationBuilder.DropTable(
                name: "UkPafFiles");

            migrationBuilder.DropTable(
                name: "IsoCountryCodes");
        }
    }
}
