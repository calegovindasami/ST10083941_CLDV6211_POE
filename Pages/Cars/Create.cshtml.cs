using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST10083941_CLDV6211_POE.Models;

namespace ST10083941_CLDV6211_POE.Pages.Cars
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
        ViewData["BodyTypeId"] = new SelectList(_context.BodyTypes, "BodyTypeId", "BodyDescription");
        ViewData["MakeId"] = new SelectList(_context.CarMakes, "MakeId", "MakeDescription");
        ViewData["ModelId"] = new SelectList(_context.CarModels, "ModelId", "ModelDescription");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //Prevents user from adding a car with an ID that exists.
            var existingCarID = _context.Cars.FirstOrDefault(c => c.CarId == Car.CarId);

            if (existingCarID != null)
            {
                ModelState.AddModelError("Car.CarId", "Car ID already exists. Please pick a new one.");
                OnGet();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
