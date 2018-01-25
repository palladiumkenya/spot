using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Spot.StatsManagement.Core.Interfaces.Repositories;
using Spot.StatsManagement.Infrastructure.Repository;

namespace Spot.StatsManagement.Infrastructure.Tests.Repository
{
    [TestFixture]
    public class FacilityRepositoryTest
   {

       private SpotContext _context;
       private IFacilityRepository _facilityRepository;

       [SetUp]
       public void SetUp()
       {
           var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
           var connectionString = config["connectionStrings:DWAPICentralConnection"];

           var options = new DbContextOptionsBuilder<SpotContext>()
               .UseSqlServer(connectionString)
               .Options;

           _context = new SpotContext(options);
           _facilityRepository = new FacilityRepository(_context);
       }

       [Test]
       public void should_Get_Facilities_Count()
       {
           var count = _facilityRepository.GetCount();

           Assert.True(count > 0);
          
       }
        [Test]
       public void should_Get_All_Facilities()
       {
           var fac = _facilityRepository.GetAll().ToList();

            Assert.True(fac.Count>0);
           foreach (var facility in fac)
           {
               Console.WriteLine(facility);
           }
       }

       [Test]
       public void should_Get_All_Facilities_With_Stats()
       {
           var facilities = _facilityRepository.GetAll(true).ToList();
           Assert.True(facilities.Count > 0);

           var fac = facilities.First();
            Assert.NotNull(fac.Stats);
           
           foreach (var facility in facilities)
           {
               Console.WriteLine($"{facility} | {facility.Stats}");
           }
       }
        [Test]
       public void should_Get_All_Facilities_By_Code()
       {
           var facilities = _facilityRepository.GetAllBy("12870").ToList();

           Assert.True(facilities.Count > 0);
           foreach (var facility in facilities)
           {
               Console.WriteLine(facility);
           }
       }
       [Test]
       public void should_Get_All_Facilities_By_Code_With_Stats()
       {
           var facilities = _facilityRepository.GetAllBy("12870",true).ToList();
           Assert.True(facilities.Count > 0);

           var fac = facilities.First();
           Assert.NotNull(fac.Stats);

           foreach (var facility in facilities)
           {
               Console.WriteLine($"{facility} | {facility.Stats}");
           }
        }

       [Test]
       public void should_Get_All_Facilities_By_Name()
       {
           var facilities = _facilityRepository.GetAllBy("amur").ToList();

           Assert.True(facilities.Count > 0);
           foreach (var facility in facilities)
           {
               Console.WriteLine(facility);
           }
       }
       [Test]
       public void should_Get_All_Facilities_By_Name_With_Stats()
       {
           var facilities = _facilityRepository.GetAllBy("amur", true).ToList();
           Assert.True(facilities.Count > 0);

           var fac = facilities.First();
           Assert.NotNull(fac.Stats);

           foreach (var facility in facilities)
           {
               Console.WriteLine($"{facility} | {facility.Stats}");
           }
       }

       [Test]
       public void should_Update_Facility_Info_With_County()
       {
           var count = _facilityRepository.UpdateFacilityInfo().Result;

           var facilities = _facilityRepository.GetAll(true).ToList();
           Assert.True(facilities.Count > 0);

           var fac = facilities.First();
           Assert.NotNull(fac.Info);

           foreach (var facility in facilities)
           {
               Console.WriteLine($"{facility} | {facility.Info}");
           }
        }
    }
}
