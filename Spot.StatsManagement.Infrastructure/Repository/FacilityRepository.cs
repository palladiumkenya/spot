using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Spot.StatsManagement.Core.Interfaces.Repositories;
using Spot.StatsManagement.Core.Model;

namespace Spot.StatsManagement.Infrastructure.Repository
{
   public class FacilityRepository:IFacilityRepository
   {

       private readonly SpotContext _context;

       public FacilityRepository(SpotContext context)
       {
           _context = context;
       }

       public int GetCount()
       {
           return _context.Facilities.Select(x => x.Id).ToList().Count;
       }

       public IEnumerable<Facility> GetAll(bool inculdeStats = false)
       {
           var facilities = _context.Facilities;

           if (inculdeStats)
               return facilities
                   .Include(x => x.Stats)
                   .ToList();
           return facilities.ToList();
       }

       public IEnumerable<Facility> GetAllBy(string searchItem, bool inculdeStats = false)
        {
            if (string.IsNullOrWhiteSpace(searchItem))
                return new List<Facility>();

            if (int.TryParse(searchItem, out int code))
            {
                var facilities = _context
                    .Facilities
                    .Where(x=>x.Code==code);

                if (inculdeStats)
                    return facilities
                        .Include(x => x.Stats)
                        .ToList();

                return facilities.ToList();
            }

            var facilitiesByName = _context
                .Facilities
                .Where(x => x.Name.ToLower().Contains(searchItem.ToLower()));

            if (inculdeStats)
                return facilitiesByName
                    .Include(x => x.Stats)
                    .ToList();

            return facilitiesByName.ToList();

        }
    }
}
