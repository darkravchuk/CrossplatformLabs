namespace Models;

public class MDM_Service
{
    public int ServiceId { get; set; } // Primary Key
    public string ServiceCategoryCode { get; set; }
    public string ServiceName { get; set; }
    public decimal ServiceCost { get; set; }
    public string ServiceDescription { get; set; }
    public string OtherDetails { get; set; }

    public ICollection<MDM_Customer_Service> MdmCustomerServices { get; set; }
}