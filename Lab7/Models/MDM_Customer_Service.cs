namespace Models;

public class MDM_Customer_Service
{
    public int CustomersServiceId { get; set; } // Primary Key
    public int MdmCustomerId { get; set; } // Foreign Key
    public int ServiceId { get; set; } // Foreign Key
    public DateTime DateServiceRequested { get; set; }
    public DateTime DateServiceReceived { get; set; }
    public decimal CostOfService { get; set; }
    public string OtherDetails { get; set; }

    public MDM_Customer MdmCustomer { get; set; }
    public MDM_Service Service { get; set; }
    public ICollection<MDM_Payment> MdmPayments { get; set; }
}