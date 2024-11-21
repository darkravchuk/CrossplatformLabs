namespace Models;

public class Electoral_Register
{
    public int ErVoterId { get; set; } // Primary Key
    public string ErAddressLine1 { get; set; }
    public string ErAddressLine2 { get; set; }
    public string ErCityTown { get; set; }
    public string ErPostcode { get; set; }
    public string ErOtherDetails { get; set; }
}