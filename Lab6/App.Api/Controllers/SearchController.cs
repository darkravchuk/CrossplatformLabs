using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;

namespace App.Api.Controllers
{
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Search API
        [HttpGet("api/search")]
        public async Task<IActionResult> Search(
            [FromQuery] DateTime? date,
            [FromQuery] List<int>? serviceIds,
            [FromQuery] string? addressStartsWith,
            [FromQuery] string? addressEndsWith)
        {
            var query = _context.MdmCustomerServices.AsQueryable();

            // Filter by date
            if (date.HasValue)
            {
                query = query.Where(cs => cs.DateServiceRequested.Date == date.Value.Date);
            }

            // Filter by service IDs
            if (serviceIds != null && serviceIds.Count > 0)
            {
                query = query.Where(cs => serviceIds.Contains(cs.ServiceId));
            }

            // Filter by start of address
            if (!string.IsNullOrEmpty(addressStartsWith))
            {
                query = query.Where(cs =>
                    cs.MdmCustomer.PatAddress.AddressLine1.StartsWith(addressStartsWith));
            }

            // Filter by end of address
            if (!string.IsNullOrEmpty(addressEndsWith))
            {
                query = query.Where(cs =>
                    cs.MdmCustomer.PatAddress.AddressLine1.EndsWith(addressEndsWith));
            }

            // Include related data (JOINs)
            var result = await query
                .Include(cs => cs.MdmCustomer)
                .ThenInclude(c => c.PatAddress)
                .Include(cs => cs.Service)
                .ToListAsync();

            return Ok(result);
        }
    }
}
