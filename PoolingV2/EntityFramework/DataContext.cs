using Microsoft.EntityFrameworkCore;
using PoolingV2.Models;

namespace PoolingV2.EntityFramework
{
    public class DataContext : DbContext
    {

        //DataContext is database
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //The following represent your tables in the database
        public DbSet<Certification> Certification { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Freelancer> Freelancer { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<FreelancerSkills> FreelancerSkills { get; set; }
        public DbSet<Skill_Pooling> Skill_Pooling { get; set; }
        public DbSet<SkillType> SkillType { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        
    }
}
