using Microsoft.EntityFrameworkCore;

namespace Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<ISO_Country_Code> ISO_Country_Codes { get; set; }
    public DbSet<UK_PAF_File> UK_PAF_Files { get; set; }
    public DbSet<MDM_Customer> MDM_Customers { get; set; }
    public DbSet<MDM_Customer_Index> MDM_Customer_Indexes { get; set; }
    public DbSet<Customer_System> Customer_Systems { get; set; }
    public DbSet<MDM_Customer_Service> MDM_Customer_Services { get; set; }
    public DbSet<MDM_Service> MDM_Services { get; set; }
    public DbSet<MDM_Payment> MDM_Payments { get; set; }
    public DbSet<Council_Tax> Council_Taxes { get; set; }
    public DbSet<Housing_Benefit> Housing_Benefits { get; set; }
    public DbSet<Social_Service> Social_Services { get; set; }
    public DbSet<Electoral_Register> Electoral_Registers { get; set; }
    public DbSet<Parking_Ticket> Parking_Tickets { get; set; }
    public DbSet<Parking_Payment> Parking_Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite keys
        modelBuilder.Entity<MDM_Customer_Index>()
            .HasKey(mci => new { mci.MdmCustomerId, mci.SystemCode });

        // Parking_Ticket and Parking_Payment relationship
        modelBuilder.Entity<Parking_Payment>()
            .HasOne(pp => pp.PtOffender)
            .WithMany(pt => pt.ParkingPayments)
            .HasForeignKey(pp => pp.PtOffenderId);

        base.OnModelCreating(modelBuilder);
    }
}