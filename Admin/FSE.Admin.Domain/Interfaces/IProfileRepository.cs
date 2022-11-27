using FSE.Admin.Domain.Models;

namespace FSE.Admin.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task<FseProfile> SearchByAssociateId(string associateId);

        Task<List<FseProfile>> SearchbyAssociateName(string name);

        Task<IEnumerable<FseProfile>> SearchBySkillName(string skillName);
    }
}
