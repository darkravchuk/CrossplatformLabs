using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace App.Api.Controllers;

[ApiController]
[Authorize]
public class HousingBenefitController : Controller
{
    private readonly ApplicationDbContext _context;

    public HousingBenefitController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("api/housing-benefits")]
    public async Task<IActionResult> Index()
    {
        var housingBenefits = await _context.HousingBenefits.ToListAsync();
        return Ok(housingBenefits);
    }

    [HttpGet("api/housing-benefits/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var housingBenefit = await _context.HousingBenefits.FirstOrDefaultAsync(hb => hb.HbRecipientId == id);

        if (housingBenefit == null)
            return NotFound();

        return Ok(housingBenefit);
    }

    [HttpPost("api/housing-benefits")]
    public async Task<IActionResult> Create([FromBody] Housing_Benefit newHousingBenefit)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _context.HousingBenefits.AddAsync(newHousingBenefit);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Details), new { id = newHousingBenefit.HbRecipientId }, newHousingBenefit);
    }

    [HttpPut("api/housing-benefits/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Housing_Benefit updatedHousingBenefit)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingHousingBenefit = await _context.HousingBenefits.FindAsync(id);
        if (existingHousingBenefit == null)
            return NotFound();

        existingHousingBenefit.HbAddress = updatedHousingBenefit.HbAddress;
        existingHousingBenefit.HbPostcode = updatedHousingBenefit.HbPostcode;
        existingHousingBenefit.HbOtherDetails = updatedHousingBenefit.HbOtherDetails;

        _context.HousingBenefits.Update(existingHousingBenefit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("api/housing-benefits/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var housingBenefit = await _context.HousingBenefits.FindAsync(id);
        if (housingBenefit == null)
            return NotFound();

        _context.HousingBenefits.Remove(housingBenefit);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
