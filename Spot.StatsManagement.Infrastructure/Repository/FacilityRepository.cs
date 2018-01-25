using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                   .Include(x=>x.Info)
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
                        .Include(x => x.Info)
                        .ToList();

                return facilities.ToList();
            }

            var facilitiesByName = _context
                .Facilities
                .Where(x => x.Name.ToLower().Contains(searchItem.ToLower()));

            if (inculdeStats)
                return facilitiesByName
                    .Include(x => x.Stats)
                    .Include(x => x.Info)
                    .ToList();

            return facilitiesByName.ToList();

        }

       public Task<int> UpdateFacilityInfo()
       {
           var sql = @"
                    UPDATE       
	                    MasterFacility
                    SET                
	                    FacilityId = f.Id
                    FROM            
	                    MasterFacility INNER JOIN
	                    Facility AS f ON MasterFacility.Code = f.Code
                    Where
	                    MasterFacility.FacilityId is null
            ";

           return _context.Database.ExecuteSqlCommandAsync(sql);
       }
   }
}
