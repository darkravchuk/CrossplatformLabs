namespace Models;

public class Parking_Ticket
{
    public int PtOffenderId { get; set; } // Primary Key
    public string PtAddress { get; set; }
    public string PtOtherDetails { get; set; }

    public ICollection<Parking_Payment> ParkingPayments { get; set; }
}