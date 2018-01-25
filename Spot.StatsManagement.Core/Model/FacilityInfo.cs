using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TimeAgo;

namespace Spot.StatsManagement.Core.Model
{
    public class FacilityInfo
    {
        public string County { get; set; }
        public Guid FacilityId { get; set; }
        public Facility Facility { get; set; }
        public override string ToString()
        {
            return $"{County}";
        }
    }
}
