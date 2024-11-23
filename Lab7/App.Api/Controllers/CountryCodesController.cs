using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace App.Api.Controllers;

[ApiController]
[Authorize]
public class CountryCodesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CountryCodesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("api/iso-country-codes")]
    public async Task<IActionResult> Index()
    {
        var countries = await _context.IsoCountryCodes
            .Select(c => new
            {
                CountryCode = c.CountryCode,
                CountryName = c.CountryName
            })
            .ToListAsync();

        return Ok(countries);
    }

    [HttpGet("api/details")]
    public async Task<IActionResult> Details(string id)
    {
        if (id == null) return NotFound();

        var country = await _context.IsoCountryCodes.FirstOrDefaultAsync(c => c.CountryCode == id);
        if (country == null) return NotFound();

        return Ok(country);
    }
}