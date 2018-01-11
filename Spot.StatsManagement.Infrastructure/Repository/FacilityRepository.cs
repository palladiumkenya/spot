using System.Collections.Generic;
using System.Linq;
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

       public IEnumerable<Facility> GetAll()
       {
          return _context.Facilities.ToList();
       }

        public IEnumerable<Facility> GetAllBy(string searchItem)
        {
            if (string.IsNullOrWhiteSpace(searchItem))
                return new List<Facility>();
            
            int code;
            if (int.TryParse(searchItem, out code))
                return _context.Facilities.Where(x => x.Code == code);

            return _context.Facilities.Where(x=>x.Name.ToLower().Contains(searchItem.ToLower())).ToList();
        }
    }
}
