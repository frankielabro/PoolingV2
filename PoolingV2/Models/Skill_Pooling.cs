using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.Models
{
    public class Skill_Pooling
    {
        public int Skill_PoolingId { get; set; }
        public string Name { get; set; }

        [ForeignKey("SkillType")]
        public int SkillTypeId { get; set; }

        public SkillType SkillType { get; set; }
    }
}
