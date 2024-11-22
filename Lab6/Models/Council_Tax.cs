namespace Models;

public class Council_Tax
{
    public int CtResidentId { get; set; } // Primary Key
    public string CtAddressLine1 { get; set; }
    public string CtAddressLine2 { get; set; }
    public string CtAddressLine3 { get; set; }
    public string CtCityTown { get; set; }
    public string CtPostcode { get; set; }
    public string CtOtherDetails { get; set; }
}
