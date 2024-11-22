namespace App.Models;

public class SearchResultViewModel
{
    public int CustomersServiceId { get; set; }
    public string ServiceName { get; set; }
    public DateTime DateServiceRequested { get; set; }
    public string Address { get; set; }
    public decimal CostOfService { get; set; }
}