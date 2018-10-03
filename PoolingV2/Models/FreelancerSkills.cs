using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.Models
{
    public class FreelancerSkills
    {
        public int FreelancerSkillsId { get; set; }

        [ForeignKey("Freelancer")]  
        public int FreelancerId { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }

        public Freelancer Freelancer { get; set; }
        public Skill_Pooling Skill { get; set; }
        
    }
}
