using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.Models
{
    public class WorkExperience
    {
        public int WorkExperienceId { get; set; }

        [ForeignKey("Freelancer")]
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

        public string CompanyName { get; set; }
        public string  Position { get; set; }
        public string WorkDescription { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}
