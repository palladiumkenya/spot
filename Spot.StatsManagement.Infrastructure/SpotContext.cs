using Microsoft.EntityFrameworkCore;
using Spot.StatsManagement.Core.Model;

namespace Spot.StatsManagement.Infrastructure
{
    public class SpotContext:DbContext
    {
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<PatientExtract> PatientExtracts { get; set; }

        public SpotContext(DbContextOptions options) : base(options)
        {
        }
    }
}