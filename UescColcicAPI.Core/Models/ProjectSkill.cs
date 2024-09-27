using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UescColcicAPI.Core
{
    public class ProjectSkill
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Skill")]
        public int SkillId { get; set; }

        public int Weight { get; set; }

        public virtual Project Project { get; set; }
        public virtual Skill Skill { get; set; }
    }
}