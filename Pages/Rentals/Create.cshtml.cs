using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST10083941_CLDV6211_POE.Models;
using Microsoft.AspNetCore.Authorization;
namespace ST10083941_CLDV6211_POE.Pages.Rentals
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ST10083941_CLDV6211_POE.Models.RentalContext _context;

        public CreateModel(ST10083941_CLDV6211_POE.Models.RentalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        //Displays Cars that are available only.
        ViewData["CarId"] = new SelectList(_context.Cars.Where(c => c.Available == "Y"), "CarId", "CarId");
        ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId");
        ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId");
            return Page();
        }

        [BindProperty]
        public Rental Rental { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var existingRentalID = _context.Rentals.FirstOrDefault(r => r.RentalId == Rental.RentalId);

            if (existingRentalID != null)
            {
                ModelState.AddModelError("Rental.RentalId", "Rental ID already exists. Please pick a new one.");
                OnGet();
            }

            if (Rental.RentalStartDate > Rental.RentalEndDate)
            {
                ModelState.AddModelError("Rental.RentalEndDate", "Rental end date cannot be before the start date.");
                OnGet();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Changes cars availability to no when the car is rented.
            var carStatus = _context.Cars.FirstOrDefault(c => c.CarId == Rental.CarId);
            carStatus.Available = "N";

            _context.Rentals.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
