using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FizzWare.NBuilder;
using Spot.StatsManagement.Core.Model;

namespace Spot.StatsManagement.Infrastructure.Tests
{
    public class TestHelper
    {
        public static IEnumerable<Facility> GetTestData(int facilityCount, int patientCount)
        {
            var facilities = Builder<Facility>.CreateListOfSize(facilityCount).Build().ToList();
            foreach (var facility in facilities)
            {
                var patientExtracts = Builder<PatientExtract>.CreateListOfSize(patientCount).All().With(x=>x.Id=Guid.NewGuid()).Build().ToList();
                facility.AddPatients(patientExtracts);
            }
            return facilities;
        }
    }
}
