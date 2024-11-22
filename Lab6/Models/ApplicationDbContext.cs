using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<ISO_Country_Code> IsoCountryCodes { get; set; }
        public DbSet<UK_PAF_File> UkPafFiles { get; set; }
        public DbSet<MDM_Customer> MdmCustomers { get; set; }
        public DbSet<MDM_Customer_Index> MdmCustomerIndexes { get; set; }
        public DbSet<Customer_System> CustomerSystems { get; set; }
        public DbSet<MDM_Customer_Service> MdmCustomerServices { get; set; }
        public DbSet<MDM_Service> MdmServices { get; set; }
        public DbSet<MDM_Payment> MdmPayments { get; set; }
        public DbSet<Council_Tax> CouncilTaxes { get; set; }
        public DbSet<Housing_Benefit> HousingBenefits { get; set; }
        public DbSet<Social_Service> SocialServices { get; set; }
        public DbSet<Electoral_Register> ElectoralRegisters { get; set; }
        public DbSet<Parking_Ticket> ParkingTickets { get; set; }
        public DbSet<Parking_Payment> ParkingPayments { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Primary Keys
            modelBuilder.Entity<ISO_Country_Code>().HasKey(x => x.CountryCode);
            modelBuilder.Entity<UK_PAF_File>().HasKey(x => x.PatAddressId);
            modelBuilder.Entity<MDM_Customer>().HasKey(x => x.MdmCustomerId);
            modelBuilder.Entity<MDM_Customer_Index>().HasKey(x => new { x.MdmCustomerId, x.SystemCode });
            modelBuilder.Entity<Customer_System>().HasKey(x => x.SystemCode);
            modelBuilder.Entity<MDM_Customer_Service>().HasKey(x => x.CustomersServiceId);
            modelBuilder.Entity<MDM_Service>().HasKey(x => x.ServiceId);
            modelBuilder.Entity<MDM_Payment>().HasKey(x => x.MdmPaymentId);
            modelBuilder.Entity<Council_Tax>().HasKey(x => x.CtResidentId);
            modelBuilder.Entity<Housing_Benefit>().HasKey(x => x.HbRecipientId);
            modelBuilder.Entity<Social_Service>().HasKey(x => x.SsClientId);
            modelBuilder.Entity<Electoral_Register>().HasKey(x => x.ErVoterId);
            modelBuilder.Entity<Parking_Ticket>().HasKey(x => x.PtOffenderId);
            modelBuilder.Entity<Parking_Payment>().HasKey(x => x.PaymentId);

            // Configure Relationships
            modelBuilder.Entity<UK_PAF_File>()
                .HasOne(x => x.CountryCodeNavigation)
                .WithMany(x => x.UKPafFiles)
                .HasForeignKey(x => x.CountryCode);

            modelBuilder.Entity<MDM_Customer>()
                .HasOne(x => x.PatAddress)
                .WithMany(x => x.MdmCustomers)
                .HasForeignKey(x => x.PatAddressId);

            modelBuilder.Entity<MDM_Customer_Index>()
                .HasOne(x => x.MdmCustomer)
                .WithMany(x => x.MdmCustomerIndexes)
                .HasForeignKey(x => x.MdmCustomerId);

            modelBuilder.Entity<MDM_Customer_Index>()
                .HasOne(x => x.System)
                .WithMany(x => x.MdmCustomerIndexes)
                .HasForeignKey(x => x.SystemCode);

            modelBuilder.Entity<MDM_Customer_Service>()
                .HasOne(x => x.MdmCustomer)
                .WithMany(x => x.MdmCustomerServices)
                .HasForeignKey(x => x.MdmCustomerId);

            modelBuilder.Entity<MDM_Customer_Service>()
                .HasOne(x => x.Service)
                .WithMany(x => x.MdmCustomerServices)
                .HasForeignKey(x => x.ServiceId);

            modelBuilder.Entity<MDM_Payment>()
                .HasOne(x => x.CustomersService)
                .WithMany(x => x.MdmPayments)
                .HasForeignKey(x => x.CustomersServiceId);

            modelBuilder.Entity<Parking_Payment>()
                .HasOne(x => x.PtOffender)
                .WithMany(x => x.ParkingPayments)
                .HasForeignKey(x => x.PtOffenderId);

            // Add Seeding Data
            DateTime fixedDate = new DateTime(2024, 11, 1, 12, 0, 0);

            // ISO_Country_Code
            modelBuilder.Entity<ISO_Country_Code>().HasData(
                new ISO_Country_Code { CountryCode = "US", CountryName = "United States" },
                new ISO_Country_Code { CountryCode = "UA", CountryName = "Ukraine" }
            );

            // UK_PAF_File
            modelBuilder.Entity<UK_PAF_File>().HasData(
                new UK_PAF_File
                {
                    PatAddressId = 1,
                    CountryCode = "US",
                    AddressLine1 = "123 Main St",
                    AddressLine2 = "Suite 200",
                    AddressLine3 = "",
                    CityTown = "New York",
                    Postcode = "10001",
                    Country = "United States"
                }
            );

            // MDM_Customer
            modelBuilder.Entity<MDM_Customer>().HasData(
                new MDM_Customer
                {
                    MdmCustomerId = 1,
                    PatAddressId = 1,
                    MdmDateOfBirth = new DateTime(1990, 1, 1),
                    OtherDetails = "Regular customer"
                }
            );

            // MDM_Customer_Index
            modelBuilder.Entity<MDM_Customer_Index>().HasData(
                new MDM_Customer_Index
                {
                    MdmCustomerId = 1,
                    SystemCode = "CT",
                    SystemCustomerId = "CT001"
                }
            );

            // Customer_System
            modelBuilder.Entity<Customer_System>().HasData(
                new Customer_System { SystemCode = "CT", SystemName = "Council Tax" },
                new Customer_System { SystemCode = "ER", SystemName = "Electoral Register" }
            );

            // MDM_Service
            modelBuilder.Entity<MDM_Service>().HasData(
                new MDM_Service
                {
                    ServiceId = 1,
                    ServiceName = "Pay Fine",
                    ServiceCost = 100.00m,
                    ServiceCategoryCode = "FINE",
                    ServiceDescription = "Parking fine payment",
                    OtherDetails = "Online service"
                }
            );

            // MDM_Customer_Service
            modelBuilder.Entity<MDM_Customer_Service>().HasData(
                new MDM_Customer_Service
                {
                    CustomersServiceId = 1,
                    MdmCustomerId = 1,
                    ServiceId = 1,
                    DateServiceRequested = fixedDate,
                    DateServiceReceived = fixedDate,
                    CostOfService = 100.00m,
                    OtherDetails = "Paid online"
                }
            );

            // MDM_Payment
            modelBuilder.Entity<MDM_Payment>().HasData(
                new MDM_Payment
                {
                    MdmPaymentId = 1,
                    CustomersServiceId = 1,
                    PaymentMethodCode = 101,
                    PaymentStatusCode = 1,
                    DateOfPayment = fixedDate,
                    AmountOfPayment = 100.00m,
                    OtherDetails = "Transaction successful"
                }
            );

            // Council_Tax
            modelBuilder.Entity<Council_Tax>().HasData(
                new Council_Tax
                {
                    CtResidentId = 1,
                    CtAddressLine1 = "123 Main St",
                    CtAddressLine2 = "",
                    CtAddressLine3 = "",
                    CtCityTown = "New York",
                    CtPostcode = "10001",
                    CtOtherDetails = "Council tax for 2023"
                }
            );

            // Housing_Benefit
            modelBuilder.Entity<Housing_Benefit>().HasData(
                new Housing_Benefit
                {
                    HbRecipientId = 1,
                    HbAddress = "456 Elm St",
                    HbPostcode = "10002",
                    HbOtherDetails = "Low-income assistance"
                }
            );

            // Social_Service
            modelBuilder.Entity<Social_Service>().HasData(
                new Social_Service
                {
                    SsClientId = 1,
                    SsOtherDetails = "Healthcare support"
                }
            );

            // Electoral_Register
            modelBuilder.Entity<Electoral_Register>().HasData(
                new Electoral_Register
                {
                    ErVoterId = 1,
                    ErAddressLine1 = "789 Oak St",
                    ErAddressLine2 = "Apt 4",
                    ErCityTown = "Los Angeles",
                    ErPostcode = "90001",
                    ErOtherDetails = "Registered voter for 2024"
                }
            );

            // Parking_Ticket
            modelBuilder.Entity<Parking_Ticket>().HasData(
                new Parking_Ticket
                {
                    PtOffenderId = 1,
                    PtAddress = "Parking Lot A",
                    PtOtherDetails = "Overtime parking violation"
                }
            );

            // Parking_Payment
            modelBuilder.Entity<Parking_Payment>().HasData(
                new Parking_Payment
                {
                    PaymentId = 1,
                    PtOffenderId = 1,
                    PaymentMethodCode = 101,
                    DateOfPayment = fixedDate,
                    AmountOfPayment = 50.00m,
                    OtherDetails = "Paid with credit card"
                }
            );
        }

    }
}
