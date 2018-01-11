using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TimeAgo;

namespace Spot.StatsManagement.Core.Model
{
    public class FacilityStat
    {
        public int NoOfPatients { get; set; }
        public DateTime? LastUpdate { get; set; }
        public Guid FacilityId { get; set; }
        public Facility Facility { get; set; }
        public string TimeAgo => LastUpdate?.TimeAgo();

        public override string ToString()
        {
            return $"{NoOfPatients} Patients, {TimeAgo}";
        }
    }
}
