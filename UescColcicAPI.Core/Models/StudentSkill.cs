using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UescColcicAPI.Core
{
    public class StudentSkill
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Skill")]
        public int SkillId { get; set; }

        public int Weight { get; set; }

        public virtual Student Student { get; set; }
        public virtual Skill Skill { get; set; }
    }
}