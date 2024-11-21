namespace Models;

public class Parking_Payment
{
    public int PaymentId { get; set; } // Primary Key
    public int PtOffenderId { get; set; } // Foreign Key
    public int PaymentMethodCode { get; set; }
    public DateTime DateOfPayment { get; set; }
    public decimal AmountOfPayment { get; set; }
    public string OtherDetails { get; set; }

    public Parking_Ticket PtOffender { get; set; }
}