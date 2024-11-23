namespace Models;

public class MDM_Customer
{
    public int MdmCustomerId { get; set; } // Primary Key
    public int PatAddressId { get; set; } // Foreign Key
    public DateTime MdmDateOfBirth { get; set; }
    public string OtherDetails { get; set; }

    public UK_PAF_File PatAddress { get; set; }
    public ICollection<MDM_Customer_Service> MdmCustomerServices { get; set; }
    public ICollection<MDM_Customer_Index> MdmCustomerIndexes { get; set; }
}