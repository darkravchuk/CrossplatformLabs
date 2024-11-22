using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Controllers;

public class CouncilTaxController : Controller
{
    private readonly ApplicationDbContext _context;

    public CouncilTaxController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("api/council-taxes")]
    public async Task<IActionResult> Index()
    {
        var councilTaxes = await _context.CouncilTaxes.ToListAsync();
        return Ok(councilTaxes);
    }

    [HttpGet("api/council-taxes/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var councilTax = await _context.CouncilTaxes.FirstOrDefaultAsync(ct => ct.CtResidentId == id);

        if (councilTax == null)
            return NotFound();

        return Ok(councilTax);
    }
}