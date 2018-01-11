using System;
using System.Collections.Immutable;
using FizzWare.NBuilder;
using NUnit.Framework;
using Spot.StatsManagement.Core.Model;

namespace Spot.StatsManagement.Core.Tests.Model
{
    [TestFixture]
    public class FacilityStatTests
    {
        private FacilityStat _facilityStat;

        [SetUp]
        public void SetUp()
        {
            _facilityStat = Builder<FacilityStat>.CreateNew().With(x => x.LastUpdate = DateTime.Now.AddHours(-5))
                .Build();
        }
        [Test]
        public void should_Have_TimeAgo()
        {
            Assert.False(string.IsNullOrWhiteSpace(_facilityStat.TimeAgo));
            Console.WriteLine(_facilityStat);

            _facilityStat.LastUpdate = null;
            Assert.True(string.IsNullOrWhiteSpace(_facilityStat.TimeAgo));
            Console.WriteLine(_facilityStat);
        }
       
    }
}
