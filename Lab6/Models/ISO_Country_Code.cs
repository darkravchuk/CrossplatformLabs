namespace Models;

public class ISO_Country_Code
{
    public string CountryCode { get; set; } // Primary Key
    public string CountryName { get; set; }
    public ICollection<UK_PAF_File> UKPafFiles { get; set; }
}
