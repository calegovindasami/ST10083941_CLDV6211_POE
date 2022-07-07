using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST10083941_CLDV6211_POE.Models;

namespace ST10083941_CLDV6211_POE.Pages.Cars
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ST10083941_CLDV6211_POE.Models.RentalContext _context;

        public EditModel(ST10083941_CLDV6211_POE.Models.RentalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars
                .Include(c => c.BodyType)
                .Include(c => c.Make)
                .Include(c => c.Model).FirstOrDefaultAsync(m => m.CarId == id);

            if (Car == null)
            {
                return NotFound();
            }
           ViewData["BodyTypeId"] = new SelectList(_context.BodyTypes, "BodyTypeId", "BodyDescription");
           ViewData["MakeId"] = new SelectList(_context.CarMakes, "MakeId", "MakeDescription");
           ViewData["ModelId"] = new SelectList(_context.CarModels, "ModelId", "ModelDescription");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.CarId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarExists(string id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
    }
}
