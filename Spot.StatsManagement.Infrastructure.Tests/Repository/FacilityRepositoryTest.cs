using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Spot.StatsManagement.Core.Interfaces.Repositories;
using Spot.StatsManagement.Core.Model;
using Spot.StatsManagement.Infrastructure.Repository;

namespace Spot.StatsManagement.Infrastructure.Tests.Repository
{
    [TestFixture]
    public class FacilityRepositoryTest
   {

       private SpotContext _context;
       private IFacilityRepository _facilityRepository;
       private List<Facility> _facilities;

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
            _context.RemoveRange(_context.PatientExtracts);
           _context.RemoveRange(_context.Facilities);
           _context.SaveChanges();

           _facilities=new List<Facility>();
           _facilities = TestHelper.GetTestData(2, 5).ToList();

            _context.Facilities.AddRange(_facilities);
           _context.SaveChanges();


           _facilityRepository = new FacilityRepository(_context);
       }

       [Test]
       public void should_Get_All_Faciliies()
       {
           var fac = _facilityRepository.GetAll().ToList();

            Assert.True(fac.Count>0);
           foreach (var facility in fac)
           {
               Console.WriteLine(facility);
           }
       }
    }
}
