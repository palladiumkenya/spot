using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spot.StatsManagement.Core.Model
{
    public class Facility
    {
        [Key]
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public virtual ICollection<PatientExtract> PatientExtracts { get; set; } = new List<PatientExtract>();

        public void AddPatients(List<PatientExtract> extracts)
        {
            foreach (var patientExtract in extracts)
            {
                patientExtract.FacilityId = Id;
                PatientExtracts.Add(patientExtract);
            }
        }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}