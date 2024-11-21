namespace Models;

public class Housing_Benefit
{
    public int HbRecipientId { get; set; } // Primary Key
    public string HbAddress { get; set; }
    public string HbPostcode { get; set; }
    public string HbOtherDetails { get; set; }
}