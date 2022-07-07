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
    public class DeleteModel : PageModel
    {
        private readonly ST10083941_CLDV6211_POE.Models.RentalContext _context;

        public DeleteModel(ST10083941_CLDV6211_POE.Models.RentalContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = await _context.Drivers.FindAsync(id);

            if (Driver != null)
            {
                _context.Drivers.Remove(Driver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
