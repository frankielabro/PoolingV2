using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.Models
{
    public class Certification
    {
        public int CertificationId { get; set; }

        [ForeignKey("Freelancer")]
        public int FreelancerId { get; set; }
        public Freelancer UseFreelancerr { get; set; }

        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime DateIssued { get; set; }
    }
}
