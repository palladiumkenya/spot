using System.Collections.Generic;
using Spot.StatsManagement.Core.Model;

namespace Spot.StatsManagement.Core.Interfaces.Repositories
{
    public interface IFacilityRepository
    {
        int GetCount();
        IEnumerable<Facility> GetAll(bool inculdeStats=false);
        IEnumerable<Facility> GetAllBy(string searchItem, bool inculdeStats = false);
    }
}