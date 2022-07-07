using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ST10083941_CLDV6211_POE.Models;
using Microsoft.AspNetCore.Authorization;
namespace ST10083941_CLDV6211_POE.Pages.Drivers
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ST10083941_CLDV6211_POE.Models.RentalContext _context;

        public DetailsModel(ST10083941_CLDV6211_POE.Models.RentalContext context)
        {
            _context = context;
        }

        public Driver Driver { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = await _context.Drivers.FirstOrDefaultAsync(m => m.DriverId == id);

            if (Driver == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
