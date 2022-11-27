using FSE.Domain.Models;

namespace FSE.Domain.AggregatesModel.ProfileAggregate
{
    public interface IProfileRepository
    {
        Task<string> AddProfile(FseProfile profile);

        Task<string> UpdateProfile(FseProfile profile);
    }
}
