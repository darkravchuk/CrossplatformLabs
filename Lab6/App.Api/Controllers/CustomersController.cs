using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Controllers;

[ApiController]
[Authorize]
public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("api/customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _context.MdmCustomers
            .Include(c => c.PatAddress) 
            .ToListAsync();

        return Ok(customers);
    }

    [HttpGet("api/customers/{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _context.MdmCustomers
            .Include(c => c.PatAddress)
            .FirstOrDefaultAsync(c => c.MdmCustomerId == id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
}