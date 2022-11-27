using FSE.Admin.Domain.Models;

namespace FSE.Admin.Domain.Interfaces
{
    public interface ISearchService
    {
        Task<FseProfile> SearchByAssociateId(string associateId);

        Task<List<FseProfile>> SearchByAssociateName(string name);

        Task<IEnumerable<FseProfile>> SearchBySkillName(string skillName);
    }
}
