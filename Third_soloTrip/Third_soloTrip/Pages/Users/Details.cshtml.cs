using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Third_soloTrip.Data;
using Third_soloTrip.Models;

namespace Third_soloTrip.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly Third_soloTrip.Data.Third_soloTripContext _context;

        public DetailsModel(Third_soloTrip.Data.Third_soloTripContext context)
        {
            _context = context;
        }

        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }
    }
}
