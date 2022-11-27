namespace FSE.Admin.Domain.Models
{
    public class FseProfile
    {
        public string? AssociateId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public List<Skill>? Skills { get; set; }
    }
}
