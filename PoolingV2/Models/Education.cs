using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.Models
{
    public class Education
    {
        public int EducationId { get; set; }

        [ForeignKey("Freelancer")]
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

        public string SchoolName { get; set; }
        public string Course { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        
    }
}
