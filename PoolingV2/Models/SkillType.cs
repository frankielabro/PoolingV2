using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.Models
{
    public class SkillType
    {
        public int SkillTypeId { get; set; }
        public string SkillTypeName { get; set; }
        
    }
}
