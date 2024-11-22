namespace Models;

public class Customer_System
{
    public string SystemCode { get; set; } // Primary Key
    public string SystemName { get; set; }

    public ICollection<MDM_Customer_Index> MdmCustomerIndexes { get; set; }
}