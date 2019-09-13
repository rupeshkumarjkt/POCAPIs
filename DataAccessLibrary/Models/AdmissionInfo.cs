using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class AdmissionInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfAdmission { get; set; }
        public decimal? AdmissionFee { get; set; }
        public decimal? TutionFee { get; set; }
    }
}
