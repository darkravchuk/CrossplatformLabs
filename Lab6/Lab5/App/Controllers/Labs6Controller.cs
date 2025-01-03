using App.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
public class Labs6Controller : Controller
{
    private readonly ApiClient _apiClient;

    public Labs6Controller(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    [HttpGet]
    public async Task<IActionResult> CountryCodes()
    {
        try
        {
            var productHoldings = await _apiClient.GetCountryCodesAsync();
            return View("CountryCodes", productHoldings);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
    
    [HttpGet("country-codes/{id}")]
    public async Task<IActionResult> CountryCodeDetails(string id)
    {
        try
        {
            var country = await _apiClient.GetCountryCodeByIdAsync(id);
            return View("CountryCodeDetails", country);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }

    
    [HttpGet]
    public async Task<IActionResult> Customers()
    {
        try
        {
            var customers = await _apiClient.GetCustomersAsync();
            return View("Customers", customers);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }

    [HttpGet("customers/{id}")]
    public async Task<IActionResult> CustomerDetail(int id)
    {
        try
        {
            var customer = await _apiClient.GetCustomerByIdAsync(id);
            return View("CustomerDetail", customer);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
    
    [HttpGet]
    public IActionResult Search()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Search(DateTime? date, List<int> serviceIds, string addressStartsWith, string addressEndsWith)
    {
        try
        {
            var results = await _apiClient.SearchAsync(date, serviceIds, addressStartsWith, addressEndsWith);
            return View("SearchResults", results);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> CouncilTax()
    {
        try
        {
            var councilTaxes = await _apiClient.GetCouncilTaxesAsync();
            return View("CouncilTax", councilTaxes);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }

    [HttpGet("council-tax/{id}")]
    public async Task<IActionResult> CouncilTaxDetails(int id)
    {
        try
        {
            var councilTax = await _apiClient.GetCouncilTaxByIdAsync(id);
            return View("CouncilTaxDetails", councilTax);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
}
