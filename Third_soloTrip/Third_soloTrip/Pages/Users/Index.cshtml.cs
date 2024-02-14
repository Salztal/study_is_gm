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
    public class IndexModel : PageModel
    {
        private readonly Third_soloTrip.Data.Third_soloTripContext _context;

        public IndexModel(Third_soloTrip.Data.Third_soloTripContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
