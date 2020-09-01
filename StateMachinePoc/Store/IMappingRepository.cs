using System.Threading.Tasks;

namespace StateMachinePoc.Store
{
    public interface IMappingRepository
    {
        Task<Mapping> GetAsync(int accountId, int entityId);
    }
}