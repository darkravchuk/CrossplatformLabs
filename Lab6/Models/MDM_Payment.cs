namespace Models;

public class MDM_Payment
{
    public int MdmPaymentId { get; set; } // Primary Key
    public int MdmCustomerId { get; set; } // Foreign Key
    public int CustomersServiceId { get; set; } // Foreign Key
    public int PaymentMethodCode { get; set; }
    public int PaymentStatusCode { get; set; }
    public DateTime DateOfPayment { get; set; }
    public decimal AmountOfPayment { get; set; }
    public string OtherDetails { get; set; }

    public MDM_Customer_Service CustomersService { get; set; }
    public MDM_Customer MdmCustomer { get; set; }
}