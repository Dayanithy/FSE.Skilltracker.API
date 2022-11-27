namespace FSE.Admin.API.Application.Models
{
    public class FseProfileDTO
    {
        public string? AssociateId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public List<SkillDTO>? Skills { get; set; }
    }
}
