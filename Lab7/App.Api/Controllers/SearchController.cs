using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.AspNetCore.Authorization;

namespace App.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("api/search")]
        public async Task<IActionResult> Search(
            [FromQuery] DateTime? date,
            [FromQuery] List<int>? serviceIds,
            [FromQuery] string? addressStartsWith,
            [FromQuery] string? addressEndsWith)
        {
            var query = _context.MdmCustomerServices.AsQueryable();

            if (date.HasValue)
            {
                query = query.Where(cs => cs.DateServiceRequested.Date == date.Value.Date);
            }

            if (serviceIds != null && serviceIds.Count > 0)
            {
                query = query.Where(cs => serviceIds.Contains(cs.ServiceId));
            }

            if (!string.IsNullOrEmpty(addressStartsWith))
            {
                query = query.Where(cs =>
                    cs.MdmCustomer.PatAddress.AddressLine1.StartsWith(addressStartsWith));
            }

            if (!string.IsNullOrEmpty(addressEndsWith))
            {
                query = query.Where(cs =>
                    cs.MdmCustomer.PatAddress.AddressLine1.EndsWith(addressEndsWith));
            }

            var result = await query
                .Include(cs => cs.MdmCustomer)
                .ThenInclude(c => c.PatAddress)
                .Include(cs => cs.Service)
                .ToListAsync();

            return Ok(result);
        }
    }
}
