using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrialWebScraper.Models
{
    public class TrialWebScraperContext : DbContext
    {
        public TrialWebScraperContext (DbContextOptions<TrialWebScraperContext> options)
            : base(options)
        {
        }

        public DbSet<TrialWebScraper.Models.SnapShot> SnapShot { get; set; }
    }
}
