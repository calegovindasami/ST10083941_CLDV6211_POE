﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ST10083941_CLDV6211_POE.Models;
using Microsoft.AspNetCore.Authorization;
namespace ST10083941_CLDV6211_POE.Pages.Rentals
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ST10083941_CLDV6211_POE.Models.RentalContext _context;

        public IndexModel(ST10083941_CLDV6211_POE.Models.RentalContext context)
        {
            _context = context;
        }


        public IList<Rental> Rental { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {

            var rentals = from r in _context.Rentals select r;

            if (!string.IsNullOrEmpty(SearchString))
            {
                rentals = rentals.Where(r => r.RentalId == SearchString);
            }


            Rental = await rentals
                .Include(r => r.Car)
                .Include(r => r.Driver)
                .Include(r => r.Inspector).ToListAsync();
        }
    }
}
