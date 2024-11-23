namespace Models;

public class UK_PAF_File
{
    public int PatAddressId { get; set; } // Primary Key
    public string CountryCode { get; set; } // Foreign Key
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string CityTown { get; set; }
    public string Postcode { get; set; }
    public string Country { get; set; }

    public ISO_Country_Code CountryCodeNavigation { get; set; }
    public ICollection<MDM_Customer> MdmCustomers { get; set; }
}