namespace Models;

public class MDM_Customer_Index
{
    public int MdmCustomerId { get; set; } // Primary Key
    public string SystemCode { get; set; } // Primary Key
    public string SystemCustomerId { get; set; }

    public MDM_Customer MdmCustomer { get; set; }
    public Customer_System System { get; set; }
}