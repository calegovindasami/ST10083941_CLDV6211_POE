using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST10083941_CLDV6211_POE.Models;

namespace ST10083941_CLDV6211_POE.Pages.Drivers
{
    public class CreateModel : PageModel
    {
        private readonly ST10083941_CLDV6211_POE.Models.RentalContext _context;

        public CreateModel(ST10083941_CLDV6211_POE.Models.RentalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Driver Driver { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var existingDriverID = _context.Drivers.FirstOrDefault(d => d.DriverId == Driver.DriverId);

            if (existingDriverID != null)
            {
                ModelState.AddModelError("Driver.DriverId", "Driver ID already exists.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Drivers.Add(Driver);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
