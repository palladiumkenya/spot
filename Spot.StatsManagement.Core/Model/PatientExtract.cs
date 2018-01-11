using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spot.StatsManagement.Core.Model
{
    public class PatientExtract
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FacilityId { get; set; }
        public DateTime? Created { get; set; }
    }
}
