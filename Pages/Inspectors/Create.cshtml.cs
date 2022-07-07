using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST10083941_CLDV6211_POE.Models;
using Microsoft.AspNetCore.Authorization;
namespace ST10083941_CLDV6211_POE.Pages.Inspectors
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
            return Page();
        }

        [BindProperty]
        public Inspector Inspector { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var existingInspectorID = _context.Inspectors.FirstOrDefault(i => i.InspectorId == Inspector.InspectorId);

            if (existingInspectorID != null)
            {
                ModelState.AddModelError("Inspector.InspectorId", "Inspector ID already exists.");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inspectors.Add(Inspector);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
