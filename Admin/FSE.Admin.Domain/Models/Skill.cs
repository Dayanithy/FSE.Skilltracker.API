namespace FSE.Admin.Domain.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public bool IsTechnical { get; set; }

        public string? SkillName { get; set; }

        public int Proficiency { get; set; }
    }
}
