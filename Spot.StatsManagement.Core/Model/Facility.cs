using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spot.StatsManagement.Core.Model
{
    [Table("Facility")]
    public class Facility
    {
        [Key]
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Emr { get; set; }
        public string Project { get; set; }
        public DateTime? Created { get; set; }
        public FacilityStat Stats { get; set; }
      
        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}