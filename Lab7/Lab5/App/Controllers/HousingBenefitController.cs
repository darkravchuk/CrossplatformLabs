using App.Clients;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
// [Route("api/v{version:apiVersion}/housing-benefits")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class HousingBenefitController: Controller
{
    private readonly ApiClient _apiClient;

    public HousingBenefitController(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
     [HttpGet]
     [MapToApiVersion("1.0")]
     [MapToApiVersion("2.0")]
    public async Task<IActionResult> HousingBenefits()
    {
        try
        {
            var housingBenefits = await _apiClient.GetHousingBenefitsAsync();
            return View("HousingBenefits", housingBenefits);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
    
    [HttpGet]
    [MapToApiVersion("2.0")]
    public IActionResult HousingBenefitsV2()
    {
        try
        {
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            return View("Error");
        }
    }

    [HttpGet("housing-benefits/{id}")]
    [MapToApiVersion("1.0")]
    [MapToApiVersion("2.0")]
    public async Task<IActionResult> HousingBenefitDetails(int id)
    {
        try
        {
            var housingBenefit = await _apiClient.GetHousingBenefitByIdAsync(id);
            return View("HousingBenefitDetails", housingBenefit);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
    
    [HttpGet("housing-benefits/v{version:apiVersion}/{id}")]
    [MapToApiVersion("2.0")]
    public async Task<IActionResult> HousingBenefitDetailsV2(int id)
    {
        try
        {
            var housingBenefit = await _apiClient.GetHousingBenefitByIdAsync(id);
            return View("HousingBenefitDetailsV2", housingBenefit);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }

    [HttpGet]
    public IActionResult CreateHousingBenefit()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateHousingBenefit(HousingBenefitViewModel newHousingBenefit)
    {
        if (!ModelState.IsValid)
            return View(newHousingBenefit);

        try
        {
            await _apiClient.CreateHousingBenefitAsync(newHousingBenefit);
            return RedirectToAction("HousingBenefits");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View(newHousingBenefit);
        }
    }

    [HttpGet("housing-benefits/edit/{id}")]
    public async Task<IActionResult> EditHousingBenefit(int id)
    {
        try
        {
            var housingBenefit = await _apiClient.GetHousingBenefitByIdAsync(id);
            return View(housingBenefit);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }

    [HttpPost("housing-benefits/edit/{id}")]
    public async Task<IActionResult> EditHousingBenefit(int id, HousingBenefitViewModel updatedHousingBenefit)
    {
        if (!ModelState.IsValid)
            return View(updatedHousingBenefit);

        try
        {
            await _apiClient.UpdateHousingBenefitAsync(id, updatedHousingBenefit);
            return RedirectToAction("HousingBenefits");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View(updatedHousingBenefit);
        }
    }

    [HttpPost("housing-benefits/delete/{id}")]
    public async Task<IActionResult> DeleteHousingBenefit(int id)
    {
        try
        {
            await _apiClient.DeleteHousingBenefitAsync(id);
            return RedirectToAction("HousingBenefits");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View("Error");
        }
    }
}