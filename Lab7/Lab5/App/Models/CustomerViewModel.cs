namespace App.Models;

public class CustomerViewModel
{
    public int MdmCustomerId { get; set; }
    public string AddressLine1 { get; set; }
    public string CityTown { get; set; }
    public string Postcode { get; set; }
    public DateTime MdmDateOfBirth { get; set; }
    public string OtherDetails { get; set; }
}