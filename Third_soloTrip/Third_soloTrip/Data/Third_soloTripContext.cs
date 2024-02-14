using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Third_soloTrip.Models;

namespace Third_soloTrip.Data
{
    public class Third_soloTripContext : DbContext
    {
        public Third_soloTripContext (DbContextOptions<Third_soloTripContext> options)
            : base(options)
        {
        }

        public DbSet<Third_soloTrip.Models.User> Users { get; set; } = default!;
    }
}
