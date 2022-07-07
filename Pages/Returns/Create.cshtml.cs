using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST10083941_CLDV6211_POE.Models;

namespace ST10083941_CLDV6211_POE.Pages.Returns
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
        ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId");
        ViewData["RentalId"] = new SelectList(_context.Rentals, "RentalId", "RentalId");
            return Page();
        }

        [BindProperty]
        public RentalReturn RentalReturn { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //Checks if return id already exists in database.
            var returnIDExists = _context.RentalReturns.FirstOrDefault(r => r.ReturnId == RentalReturn.ReturnId);

            if (returnIDExists != null)
            {
                ModelState.AddModelError("RentalReturn.ReturnId", "Return ID already exists.");
                OnGet();
            }
            

            var initialReturnDate = (from rental in _context.Rentals
                                     where rental.RentalId == RentalReturn.RentalId
                                     select rental.RentalEndDate).Single();
            var rentalStartDate = (from rental in _context.Rentals
                                   where rental.RentalId == RentalReturn.RentalId
                                   select rental.RentalStartDate).Single();

            //Checks if the return date is before the date it was rented out.
            if (rentalStartDate > RentalReturn.ReturnDate)
            {
                ModelState.AddModelError("RentalReturn.ReturnDate", "Return date cannot be before vehicle was rented.");
                OnGet();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Calculates the daily fine
            double daysLate = (RentalReturn.ReturnDate - initialReturnDate).TotalDays;
            decimal fine = (int)daysLate * 500M;
            RentalReturn.DailyFine = fine;

            _context.RentalReturns.Add(RentalReturn);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
