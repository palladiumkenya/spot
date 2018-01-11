using System.Collections.Generic;
using Spot.StatsManagement.Core.Model;

namespace Spot.StatsManagement.Core.Interfaces.Repositories
{
    public interface IFacilityRepository
    {
        IEnumerable<Facility> GetAll();
        IEnumerable<Facility> GetAllBy(string searchItem);
    }
}