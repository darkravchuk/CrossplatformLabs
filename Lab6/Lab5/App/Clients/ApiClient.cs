using App.Models;

namespace App.Clients;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<IsoCountryCodeViewModel>> GetCountryCodesAsync()
    {
        var response = await _httpClient.GetAsync("/api/iso-country-codes");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<IsoCountryCodeViewModel>>();
    }
    // New method to get all customers
    public async Task<List<CustomerViewModel>> GetCustomersAsync()
    {
        var response = await _httpClient.GetAsync("/api/customers");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<CustomerViewModel>>();
    }

    // New method to get a single customer by ID
    public async Task<CustomerViewModel> GetCustomerByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/customers/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerViewModel>();
    }
    
    public async Task<List<SearchResultViewModel>> SearchAsync(DateTime? date, List<int> serviceIds, string addressStartsWith, string addressEndsWith)
    {
        var query = $"/api/search?";
        if (date.HasValue)
            query += $"date={date.Value:yyyy-MM-dd}&";
        if (serviceIds != null && serviceIds.Count > 0)
            query += string.Join("&", serviceIds.Select(id => $"serviceIds={id}")) + "&";
        if (!string.IsNullOrEmpty(addressStartsWith))
            query += $"addressStartsWith={addressStartsWith}&";
        if (!string.IsNullOrEmpty(addressEndsWith))
            query += $"addressEndsWith={addressEndsWith}&";

        var response = await _httpClient.GetAsync(query.TrimEnd('&'));
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<SearchResultViewModel>>();
    }
}