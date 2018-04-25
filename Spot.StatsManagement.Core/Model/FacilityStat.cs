using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Humanizer;


namespace Spot.StatsManagement.Core.Model
{
    public class FacilityStat
    {
        public int NoOfPatients { get; set; }
        public DateTime? LastUpdate { get; set; }
        public Guid FacilityId { get; set; }
        public Facility Facility { get; set; }
        public string TimeAgo => LastUpdate?.Humanize(false);

        public override string ToString()
        {
            return $"{NoOfPatients} Patients, {TimeAgo}";
        }
    }
}
